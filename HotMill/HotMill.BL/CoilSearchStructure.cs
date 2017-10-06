using System;
using System.Data;

namespace Kvics.HotMill.BL
{
    public class GroupSearch
    {
        public bool A = false;
        public bool B = false;
        public bool C = false;
        public bool D = false;

        public GroupSearch(bool a, bool b, bool c, bool d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }
    }

    public enum RollMaterialSearch : int
    {
        Haisu = 1,
        Other = 2,
        Unknown = 0
    }

    public enum MaterialType : int
    {
        Steel = 1,
        Ni = 2,
        Ti = 3,
        Plate = 4,
        Unknown = 0
    }

    public enum Stand : int
    {
        F5 = 5,
        F6 = 6,
        F7 = 7,
        Unknown = 0
    }

    public class CoilSearchStructure
    {
        public string BeginDate;
        public string EndDate;
        public string CoilNo;
        public string SteelName;
        public double CacbonBegin;
        public double CacbonEnd;
        public double ThickBegin;
        public double ThickEnd;
        public double WidthBegin;
        public double WidthEnd;
        public double TemperatureBegin;
        public double TemperatureEnd;
        public RollMaterialSearch F4Material;
        public RollMaterialSearch F5Material;
        public RollMaterialSearch F6Material;
        public RollMaterialSearch F7Material;
        public GroupSearch Group;
        public WorkerCollection WorkerList;

        public int PageNo;
        public int PageSize;
    }

    public class CoilSearchResultStructure
    {
        public DataSet ResultData;
        public long ItemsCount;
        public int PageNo;
        public int PageSize;

        public CoilSearchResultStructure(DataSet resultData, long itemsCount, int pageNo, int pageSize)
        {
            ItemsCount = itemsCount;
            ResultData = resultData;
            PageNo = pageNo;
            PageSize = pageSize;
        }
    }

    //public enum 

    public class CoilPressureDifferenceTotalStructure
    {
        public string BeginDate;
        public string EndDate;
        public MaterialType MaterialType = MaterialType.Unknown;
        public Stand Stand = Stand.Unknown;
        public RollMaterialSearch F5Material = RollMaterialSearch.Unknown;
        public RollMaterialSearch F6Material = RollMaterialSearch.Unknown;
        public RollMaterialSearch F7Material = RollMaterialSearch.Unknown;
        public GroupSearch Group;
        public WorkerCollection WorkerList;
    }

}
