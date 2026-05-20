using IntelOrca.Biohazard.BioRand;
using IntelOrca.Biohazard.REE.Messages;
using IntelOrca.Biohazard.REE.Rsz;
using System.Diagnostics;

namespace Biohazard.BioRand.RE7.Extensions;

public static class PatchContextExtensions {
    extension(IPatchContext context) {
        public void SetFile(string path, ReadOnlyMemory<byte> data) =>
            context.SetFile(path, data.ToArray());

        public bool Exists(string path) => context.GetFile(path) != null;

        public PfbFile GetPfbFile(string path) {
            var data = context.GetFile(path);
            return data == null
                ? throw new Exception("Unable to read data file.")
                : new PfbFile(17, data);
        }

        public void ModifyPfbFile(string path, Func<RszScene, RszScene> callback) {
            var pfbFile = context.GetPfbFile(path).ToBuilder(context.TypeRepository);
            pfbFile.Scene = callback(pfbFile.Scene);
            context.SetPfbFile(path, pfbFile.AddMissingResources().Build());
        }

        public void SetPfbFile(string path, PfbFile value) {
            context.SetFile(path, value.Data);
        }

        public ScnFile GetScnFile(string path) {
            var data = context.GetFile(path);
            if (data != null) {
                return new ScnFile(FileVersions.SceneFileVersion, data);
            }

            var stackTrace = new StackTrace();
            throw new RandomizerUserException(
                $"Unable to read data file '{path}'\n{string.Join('\n', stackTrace.GetFrames())}");
        }

        public void ModifyScnFile(string path, Func<RszScene, RszScene> callback) {
            var scnFile = context.GetScnFile(path).ToBuilder(context.TypeRepository);
            scnFile.Scene = callback(scnFile.Scene);
            context.SetScnFile(path, scnFile.AddMissingResources().Build());
        }

        public void SetScnFile(string path, ScnFile value) {
            context.SetFile(path, value.Data);
        }

        public UserFile GetUserFile(string path) {
            var data = context.GetFile(path);
            return data == null
                ? throw new Exception($"Unable to read data file '{path}'.")
                : new UserFile(data);
        }

        public T DeserializeUserFile<T>(string path) {
            var userFile = context.GetUserFile(path);
            return RszSerializer.Deserialize<T>(userFile.GetObjects(context.TypeRepository)[0])!;
        }

        public void SerializeUserFile<T>(string path, T value) {
            var userFile = context.GetUserFile(path);
            var builder = userFile.ToBuilder(context.TypeRepository);
            var targetType = builder.Objects[0].Type;
            builder.Objects = [(RszObjectNode)RszSerializer.Serialize(targetType, value!)];
            context.SetUserFile(path, builder.Build());
        }

        public void SetUserFile(string path, UserFile value) {
            context.SetFile(path, value.Data);
        }

        public void ModifyUserFile(string path, Func<RszObjectNode, RszObjectNode> callback) {
            var userFile = context.GetUserFile(path);
            var builder = userFile.ToBuilder(context.TypeRepository);
            builder.Objects = [callback(builder.Objects[0])];
            context.SetUserFile(path, builder.Build());
        }

        public void ModifyUserFile<T>(string path, Func<T, T> callback) {
            var userFile = context.GetUserFile(path);
            var builder = userFile.ToBuilder(context.TypeRepository);
            var targetType = builder.Objects[0].Type;
            var value = RszSerializer.Deserialize<T>(builder.Objects[0])!;
            var updatedValue = callback(value);
            builder.Objects = [(RszObjectNode)RszSerializer.Serialize(targetType, updatedValue!)];
            context.SetUserFile(path, builder.Build());
        }

        public MsgFile GetMsgFile(string path) {
            return new MsgFile(context.GetFile(path));
        }

        public void SetMsgFile(string path, MsgFile msg) {
            context.SetFile(path, msg.Data.ToArray());
        }

        public void ModifyMsgFile(string path, Action<MsgFile.Builder> callback) {
            var msgFile = context.GetMsgFile(path);
            var builder = msgFile.ToBuilder();
            callback(builder);
            context.SetMsgFile(path, builder.Build());
        }

        public RcolFile GetRcolFile(string path) {
            var data = context.GetFile(path);
            if (data == null || data.Length < 4)
                throw new RandomizerUserException($"Unable to read RCOL file '{path}'.");

            return new RcolFile(FileVersions.RcolFileVersion, data);
        }

        public void SetRcolFile(string path, RcolFile rcol) {
            context.SetFile(path, rcol.Data.ToArray());
        }

        public void ModifyRcolFile(string path, Action<RcolFile.Builder> callback) {
            var rcolFile = context.GetRcolFile(path);
            var builder = rcolFile.ToBuilder(context.TypeRepository);
            callback(builder);
            context.SetRcolFile(path, builder.Build());
        }

        public void ApplyOverlay(byte[] zipData) {
            var supplementZip = new ZipArchive(new MemoryStream(zipData));
            foreach (var entry in supplementZip.Entries) {
                if (entry.Length == 0)
                    continue;

                var data = entry.GetData();
                context.SetFile(entry.FullName, data);
            }
        }
    }
}