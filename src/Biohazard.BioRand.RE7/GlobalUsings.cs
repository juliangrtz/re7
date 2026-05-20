// Often used dependencies

global using Biohazard.BioRand.RE7.Extensions;
global using System;
global using System.Collections;
global using System.Collections.Generic;
global using System.IO;
global using System.IO.Compression;
global using System.Linq;
global using System.Text;

// Syntactic sugar for RSZ types
global using Recipe = app.ItemCombineData.Data;
global using StartingInventoryItem = app.AddItemListData.Data;
global using ItemDropTable = app.ReliefItemTable;
global using ItemDropDistribution = app.ReliefItemTable.ReliefItemTableData;