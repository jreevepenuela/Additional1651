using PX.Data;

namespace Additional1651
{
    public class SOShipmentExtension : PXCacheExtension<PX.Objects.SO.SOShipment>
    {
        #region UsrTruckNo2
        [PXDBString]
        [PXUIField(DisplayName = "Truck No")]

        public string UsrTruckNo2 { get; set; }
        public abstract class usrTruckNo2 : PX.Data.BQL.BqlString.Field<usrTruckNo2> { }
        #endregion

        #region Usrshipmenttypee
        [PXDBString]
        [PXUIField(DisplayName = "Shipment Type")]
        [PXStringList(new string[] { "DR", "AR" }, new string[] { "Delivery Receipt", "Acknowledgement Receipt" })]

        public string Usrshipmenttypee { get; set; }
        public abstract class usrshipmenttypee : PX.Data.BQL.BqlString.Field<usrshipmenttypee> { }
        #endregion

        #region Usrshipmentnoo
        [PXDBString]
        [PXUIField(DisplayName = "shipmentno")]

        public string Usrshipmentnoo { get; set; }
        public abstract class usrshipmentnoo : PX.Data.BQL.BqlString.Field<usrshipmentnoo> { }
        #endregion

        #region UsrShipmentNBrs
        [PXDBInt]
        [PXUIField(DisplayName = "Receipt #")]

        public int? UsrShipmentNBrs { get; set; }
        public abstract class usrShipmentNBrs : PX.Data.BQL.BqlInt.Field<usrShipmentNBrs> { }
        #endregion

        #region Usrfinalshipnbr
        [PXDBString]
        [PXUIField(DisplayName = "Document Nbr.")]

        public string Usrfinalshipnbr { get; set; }
        public abstract class usrfinalshipnbr : PX.Data.BQL.BqlString.Field<usrfinalshipnbr> { }
        #endregion

        #region Usrshipmenttypees
        [PXDBString]
        [PXUIField(DisplayName = "shipmenttypees")]
        [PXStringList(new string[] { "DR", "AR" }, new string[] { "Delivery Receipt", "Acknowledgement Receipt" })]
        public string Usrshipmenttypees { get; set; }
        public abstract class usrshipmenttypees : PX.Data.BQL.BqlString.Field<usrshipmenttypees> { }
        #endregion
    }
}
