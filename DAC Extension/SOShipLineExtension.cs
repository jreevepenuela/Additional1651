using PX.Data;
using PX.Objects.SO;

namespace Additional1651
{
    public class SOShipLineExtension : PXCacheExtension<SOShipLine>
    {
        #region UsrCustomLocation
        [PXDBString]
        [PXUIField(DisplayName = "CustomLocation")]
        //[PXDefault(typeof(Search<SOLineExt.usrCustomerLocation, Where<SOLine.inventoryID, Equal<Required<SOShipLine.inventoryID>>>>))]
        public string UsrCustomLocation { get; set; }
        public abstract class usrCustomLocation : PX.Data.BQL.BqlString.Field<usrCustomLocation> { }
        #endregion
    }
}
