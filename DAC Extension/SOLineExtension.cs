using PX.Data;
using PX.Objects.CR;
using PX.Objects.SO;
using System;

namespace Additional1651
{
    public class SOLineExtension : PXCacheExtension<SOLine>
    {
        #region UsrWarrantydate
        [PXDBDate]
        [PXUIField(DisplayName = "Warrantydate")]

        public virtual DateTime? UsrWarrantydate { get; set; }
        public abstract class usrWarrantydate : PX.Data.BQL.BqlDateTime.Field<usrWarrantydate> { }
        #endregion

        #region UsrCustomerLocation
        [PXDBString]
        [PXUIField(DisplayName = "CustomerLocation")]
        [PXSelector(typeof(Search<Location.locationCD, Where<Location.bAccountID, Equal<Current<SOOrder.customerID>>>>))]
        public virtual string UsrCustomerLocation { get; set; }
        public abstract class usrCustomerLocation : PX.Data.BQL.BqlString.Field<usrCustomerLocation> { }
        #endregion

        #region UsrWarrantyperiod
        [PXDBInt]
        [PXUIField(DisplayName = "Warrantyperiod")]

        public virtual int? UsrWarrantyperiod { get; set; }
        public abstract class usrWarrantyperiod : PX.Data.BQL.BqlInt.Field<usrWarrantyperiod> { }
        #endregion
    }
}
