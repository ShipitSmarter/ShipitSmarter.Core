# Setup of Domain models

We encountered a lot of shared models across `shipping` and `carrier-gateway`.  
In this document we describe the shared models in both of these applications and find a common base to make up or domain models.

## `Shipment`

**common**

- `Reference` (`string`)
- `LocationReference` (`string`)
- `Addresses` (`AddressCollection`)
- `DimensionUnit` (`DimensionUnit`)
- `WeightUnit` (`WeighUnit`)
- `Description` (`string?`)
- `DeclaredValue` (`Amount?`)
- `TimeWindows` (`TimeWindows`)
- `Incoterms` (`Incoterms?`)
- `Inbound` (`bool?`)
- `ServiceLevelReference` (`string?`)
- `ServiceOptions` (`ServiceOptionsModel?`)
- `References` (`ShipmentReferenceCollection?`)
- `Instructions` (`ShipmentInstructions?`)
- `CommercialInvoice` (`CommercialInvoice?`)
- `ContainsDangerousGoods` (`bool`) => (`DerivedDetermination.ContainsDangerousGoods(HandlingUnits)`)
- `HandlingUnits`
    - (`List<T> where T : HandlingUnit`)
    - (`List<HandlingUnit>`)

**carrier-gateway**

`BaseShipment<T> where T : HandlingUnit`

- `ShipmentCode` (`string?`)
- `Accounts` (`Accounts?`)
- `IsDomestic` (`bool`) => (`DerivedDetermination.IsDomestic(Addresses)`)
- `IsDutiable` (`bool?`) => (`DerivedDetermination.IsDutiable(this)`)

`BaseShipmentWithCarrierReference<T> : BaseShipment<T>`

- `CarrierReference` (`string`)

**shipping**

`Shipment`

- `CarrierReference` (`string?`)
- `RequestedTrackingReference` (`string?`)
- `Documents` (`List<RequestedDocuments>?`)

### `AddressCollection`

**common**

- `Sender` (`AddressWithAccount`)
- `Receiver` (`AddressWithAccount`)
- `Collection` (`Address`)
- `DutiesTaxes` (`AddressWithAccount?`)
- `ThirdParty` (`AddressWithAccount?`)
- `Buyer` (`Address?`)
- `Seller` (`Address?`)
- `Ultimate` (`Address?`)
- `Broker` (`AddressWithAccount?`)
- `ImporterOfRecord` (`AddressWithAccount?`)
- `DropOff` (`DropOffAddress?`)
- `Return` (`Address?`)
- `CarrierAgent` (`AddressWithAccount?`)
- `Notify` (`Address?`)
- `NeutralSender` (`Address?`)

**carrier-gateway**

- `ShippingLocation` (`Address?`)

**shipping**

No differences

#### `Address`, `AddressWithAccount`, `DropOffAddress`

All equal. For `Address`, carrier-gateway contains documentation and an overwrite of `Eqauls` which suggests it should be made a `record`.


### `HandlingUnit`

**common**

- `Sequence` (`int`)
- `Weight` (`decimal`)
- `Length` (`decimal`)
- `Width` (`decimal`)
- `Height` (`decimal`)
- `PackageTypeCode` (`PackageType`)
- `IsDocument` (`bool`)
- `Description` (`string?`)
- `IsStackable` (`bool?`)
- `References` (`HandlingUnitReferences?`)
- `ServiceOptions` (`HandlingUnitServiceOptions?`)
- `GoodsItems` (`List<GoodItems>`)

**carrier-gateway**

No differences

**shipping**

`HandlingUnit : CarrierGateWay.HandlingUnit`

- `RequestedTrackingReference` (`string?`)
