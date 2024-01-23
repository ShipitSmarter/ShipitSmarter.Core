using System.Text.Json.Serialization;
using Ardalis.SmartEnum;

namespace ShipitSmarter.Core.Enumerations.HandlingUnit.v1;

/// <summary>
/// Package types; see https://viya.me/documentation/carrier-integration/package-types/ for more information
/// </summary>
[JsonConverter(typeof(SmartEnumNameConverter<PackageType, string>))]
public sealed class PackageType : SmartEnum<PackageType, string>
{
    // ReSharper disable InconsistentNaming
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static readonly PackageType Box = new ("box", "Box");
    public static readonly PackageType CageRoll = new ("cage-roll", "Cage, roll");
    public static readonly PackageType Crate = new ("crate", "Crate");
    public static readonly PackageType Envelope = new ("envelope", "Envelope");
    public static readonly PackageType Pallet100x120Euro = new ("pallet-100x120-euro", "Block Pallet 100cmx120cm");
    public static readonly PackageType Pallet80x120Euro = new ("pallet-80x120-euro", "Euro Pallet (EPAL)");
    public static readonly PackageType Pallet80x60Euro = new ("pallet-80x60-euro", "1/2 Euro Pallet Size (EPAL)");
    public static readonly PackageType Pallet60x40Euro = new ("pallet-60x40-euro", "1/4 EURO Pallet Size (EPAL)");
    public static readonly PackageType Pallet40x30Euro = new ("pallet-40x30-euro", "1/8 Euro Size Pallet (EPAL)");
    public static readonly PackageType Pallet100x120Oneway = new ("pallet-100x120-oneway", "Oneway pallet 100cmx120cm");
    public static readonly PackageType Pallet80x120Oneway = new ("pallet-80x120-oneway", "Oneway pallet 80cmx120cm");
    public static readonly PackageType Pallet80x60Oneway = new ("pallet-80x60-oneway", "Oneway pallet 80cmx60cm");
    public static readonly PackageType PalletBox = new ("pallet-box", "Pallet, box Combined open-ended box and pallet");
    public static readonly PackageType Unpacked = new ("unpacked", "Unpacked or unpackaged");
    public static readonly PackageType CarrierEnvelope = new ("carrier-envelope", "Max 1lbs, 0.5kg");
    public static readonly PackageType Carrier10kgBox = new ("carrier-10kg-box", "Box max 22lbs, 10kg");
    public static readonly PackageType Carrier25kgBox = new ("carrier-25kg-box", "Box max 55lbs, 25kg");
    public static readonly PackageType CarrierLargeBox = new ("carrier-large-box", "Box max 20lbs, 9kg");
    public static readonly PackageType CarrierMediumBox = new ("carrier-medium-box", "Box max 20lbs, 9kg");
    public static readonly PackageType CarrierPak = new ("carrier-pak", "Box max 20lbs, 9kg");
    public static readonly PackageType CarrierSmallBox = new ("carrier-small-box", "Box max 20lbs, 9kg");
    public static readonly PackageType CarrierTube = new ("carrier-tube", "Box max 20lbs, 9kg");
    
    public static readonly PackageType Bag = new("bag","Bag");
    public static readonly PackageType BagFlexi = new("bag-flexi","Flexibag");
    public static readonly PackageType BagGunny = new("bag-gunny","Bag, gunny");
    public static readonly PackageType BagJute = new("bag-jute","Jutebag");
    public static readonly PackageType BagLarge = new("bag-large","Bag, large ");
    public static readonly PackageType BagMultiWall = new("bag-multi-wall","Sack, multi-wall ");
    public static readonly PackageType BagPaper = new("bag-paper","Bag, paper ");
    public static readonly PackageType BagPaperMultiWall = new("bag-paper-multi-wall","Bag, paper, multi-wall ");
    public static readonly PackageType BagPaperMultiWallWaterResistant = new("bag-paper-multi-wall-water-resistant","Bag, paper, multi-wall, water resistant");
    public static readonly PackageType BagPlastic = new("bag-plastic","Bag, plastic ");
    public static readonly PackageType BagPlasticsFilm = new("bag-plastics-film","Bag, plastics film ");
    public static readonly PackageType BagPoly = new("bag-poly","Bag, polybag");
    public static readonly PackageType BagTextile = new("bag-textile","Bag, textile ");
    public static readonly PackageType BagTextileSiftProof = new("bag-textile-sift-proof","Bag, textile, sift proof ");
    public static readonly PackageType BagTextileWaterResistant = new("bag-textile-water-resistant","Bag, textile, water resistant");
    public static readonly PackageType BagTextileWithoutCoatLiner = new("bag-textile-without-coat-liner","Bag, textile, without inner coat/liner ");
    public static readonly PackageType BagWovenPlastic = new("bag-woven-plastic","Bag, woven plastic");
    public static readonly PackageType BagWovenPlasticSiftProof = new("bag-woven-plastic-sift-proof","Bag, woven plastic, sift proof ");
    public static readonly PackageType BagWovenPlasticWaterResistant = new("bag-woven-plastic-water-resistant","Bag, woven plastic, water resistant");
    public static readonly PackageType BagWovenPlasticWithoutCoatLiner = new("bag-woven-plastic-without-coat-liner","Bag, woven plastic, without inner coat/liner ");
    public static readonly PackageType BaleCompressed = new("bale-compressed","Bale, compressed ");
    public static readonly PackageType BaleNonCompressed = new("bale-non-compressed","Bale, non-compressed ");
    public static readonly PackageType Barrel = new("barrel","Barrel ");
    public static readonly PackageType BarrelWooden = new("barrel-wooden","Barrel, wooden");
    public static readonly PackageType BarrelWoodenBungType = new("barrel-wooden-bung-type","Barrel, wooden, bung type");
    public static readonly PackageType BarrelWoodenRemovableHead = new("barrel-wooden-removable-head","Barrel, wooden, removable head ");
    public static readonly PackageType Basket = new("basket","Basket ");
    public static readonly PackageType BasketCardboard = new("basket-cardboard","Basket, with handle, cardboard ");
    public static readonly PackageType BasketPlastic = new("basket-plastic","Basket, with handle, plastic ");
    public static readonly PackageType BasketWooden = new("basket-wooden","Basket, with handle, wooden");
    public static readonly PackageType Bin = new("bin","Bin");
    public static readonly PackageType BottleGas = new("bottle-gas","Bottle, gas");
    public static readonly PackageType BoxAluminium = new("box-aluminium","Box, aluminium");
    public static readonly PackageType BoxChep = new("box-chep","Box, Commonwealth Handling Equipment Pool (CHEP), Eurobox");
    public static readonly PackageType BoxFibreboard = new("box-fibreboard","Box, fibreboard");
    public static readonly PackageType BoxForLiquids = new("box-for-liquids","Box, for liquids");
    public static readonly PackageType BoxNaturalWood = new("box-natural-wood","Box, natural wood");
    public static readonly PackageType BoxNaturalWoodOrdinary = new("box-natural-wood-ordinary","Box, wooden, natural wood, ordinary");
    public static readonly PackageType BoxNaturalWoordSiftProof = new("box-natural-woord-sift-proof","Box, wooden, natural wood, with sift proof walls");
    public static readonly PackageType BoxPlastic = new("box-plastic","Box, plastic");
    public static readonly PackageType BoxPlasticExpanded = new("box-plastic-expanded","Box, plastic, expanded ");
    public static readonly PackageType BoxPlasticSolid = new("box-plastic-solid","Box, plastic, solid");
    public static readonly PackageType BoxPlywood = new("box-plywood","Box, plywood");
    public static readonly PackageType BoxReconstructedWood = new("box-reconstructed-wood","Box, reconstituted wood");
    public static readonly PackageType BoxSteel = new("box-steel","Box, steel");
    public static readonly PackageType BoxWooden = new("box-wooden","Lug");
    public static readonly PackageType Bucket = new("bucket","Bucket ");
    public static readonly PackageType BulkGas = new("bulk-gas","Bulk, gas (at 1031 mbar and 15°C)");
    public static readonly PackageType BulkLiquefiedGas = new("bulk-liquefied-gas","Bulk, liquefied gas (at abnormal temperature/pressure) ");
    public static readonly PackageType BulkLiquid = new("bulk-liquid","Bulk, liquid ");
    public static readonly PackageType BulkScrapMetal = new("bulk-scrap-metal","Bulk, scrap metal");
    public static readonly PackageType BulkSolid = new("bulk-solid","Bulk, solid, large particles (“nodules”) ");
    public static readonly PackageType BulkSolidGrains = new("bulk-solid-grains","Bulk, solid, granular particles (“grains”) ");
    public static readonly PackageType BulkSolidPowders = new("bulk-solid-powders","Bulk, solid, fine particles (“powders”)");
    public static readonly PackageType Bundle = new("bundle","Bundle ");
    public static readonly PackageType Cage = new("cage","Cage ");
    public static readonly PackageType CageChep = new("cage-chep","Cage, Commonwealth Handling Equipment Pool  (CHEP)");
    public static readonly PackageType CageWheels900x770x1513 = new("cage-wheels-900x770x1513","Two sided cage on wheels with fixing strap");
    public static readonly PackageType Can = new("can","Can, cylindrical ");
    public static readonly PackageType CanRectangular = new("can-rectangular","Can, rectangular ");
    public static readonly PackageType CarboyNonProtected = new("carboy-non-protected","Carboy, protected");
    public static readonly PackageType CarboyProtected = new("carboy-protected","Carboy, non-protected");
    public static readonly PackageType Case = new("case","Case ");
    public static readonly PackageType CaseIsothermic = new("case-isothermic","Case, isothermic ");
    public static readonly PackageType CaseSkeleton = new("case-skeleton","Case, skeleton ");
    public static readonly PackageType CaseSteel = new("case-steel","Case, steel");
    public static readonly PackageType CaseWooden = new("case-wooden","Case, wooden");
    public static readonly PackageType Chest = new("chest","Chest");
    public static readonly PackageType ChestSea = new("chest-sea","Sea-chest");
    public static readonly PackageType Churn = new("churn","Churn");
    public static readonly PackageType Coffin = new("coffin","Coffin ");
    public static readonly PackageType Coil = new("coil","Coil ");
    public static readonly PackageType ContainerMetal = new("container-metal","Container, metal");
    public static readonly PackageType CrateBeer = new("crate-beer","Crate, beer");
    public static readonly PackageType CrateBottlerack = new("crate-bottlerack","Bottlecrate / bottlerack ");
    public static readonly PackageType CrateBulkCardboard = new("crate-bulk-cardboard","Crate, bulk, cardboard ");
    public static readonly PackageType CrateBulkPlastic = new("crate-bulk-plastic","Crate, bulk, plastic ");
    public static readonly PackageType CrateBulkWooden = new("crate-bulk-wooden","Crate, bulk, wooden");
    public static readonly PackageType CrateFramed = new("crate-framed","Crate, framed");
    public static readonly PackageType CrateFruit = new("crate-fruit","Crate, fruit ");
    public static readonly PackageType CrateMetal = new("crate-metal","Crate, metal");
    public static readonly PackageType CrateMilk = new("crate-milk","Crate, milk");
    public static readonly PackageType CrateMultiLayerCardboard = new("crate-multi-layer-cardboard","Crate, multiple layer, cardboard ");
    public static readonly PackageType CrateMultiLayerPlastic = new("crate-multi-layer-plastic","Crate, multiple layer, plastic ");
    public static readonly PackageType CrateMultiLayerWooden = new("crate-multi-layer-wooden","Crate, multiple layer, wooden");
    public static readonly PackageType CrateShallow = new("crate-shallow","Crate, shallow ");
    public static readonly PackageType CrateWooden = new("crate-wooden","Crate, wooden");
    public static readonly PackageType Cylinder = new("cylinder","Cylinder ");
    public static readonly PackageType Drum = new("drum","Container, flexible");
    public static readonly PackageType DrumAluminium = new("drum-aluminium","Drum, aluminium");
    public static readonly PackageType DrumAluminiumNonRemovableHead = new("drum-aluminium-non-removable-head","Drum, aluminium, non-removable head");
    public static readonly PackageType DrumAluminiumRemovableHead = new("drum-aluminium-removable-head","Drum, aluminium, removable head");
    public static readonly PackageType DrumFibreboard = new("drum-fibreboard","Drum, fibre");
    public static readonly PackageType DrumIron = new("drum-iron","Drum, iron ");
    public static readonly PackageType DrumPlastic = new("drum-plastic","Drum, plastic");
    public static readonly PackageType DrumPlasticNonRemovableHead = new("drum-plastic-non-removable-head","Drum, plastic, non-removable head");
    public static readonly PackageType DrumPlasticRemovableHead = new("drum-plastic-removable-head","Drum, plastic, removable head");
    public static readonly PackageType DrumPlywood = new("drum-plywood","Drum, plywood");
    public static readonly PackageType DrumSteel = new("drum-steel","Drum, steel");
    public static readonly PackageType DrumSteelRemovableHead = new("drum-steel-removable-head","Drum, steel, removable head");
    public static readonly PackageType DrumWooden = new("drum-wooden","Drum, wooden");
    public static readonly PackageType DumSteelNonRemovableHead = new("dum-steel-non-removable-head","Drum, steel, non-removable head");
    public static readonly PackageType EnvelopeSteel = new("envelope-steel","Envelope, steel");
    public static readonly PackageType Firkin = new("firkin","Firkin ");
    public static readonly PackageType Foodtainer = new("foodtainer","Foodtainer");
    public static readonly PackageType Frame = new("frame","Frame");
    public static readonly PackageType HamperWickerwork = new("hamper-wickerwork","Composite packaging, glass receptacle in wickerwork hamper");
    public static readonly PackageType Hanger = new("hanger","Hanger");
    public static readonly PackageType Hogshead = new("hogshead","Hogshead ");
    public static readonly PackageType IbcAluminium = new("ibc-aluminium","Intermediate bulk container, aluminium ");
    public static readonly PackageType IbcAluminiumLiquid = new("ibc-aluminium-liquid","Intermediate bulk container, aluminium, liquid ");
    public static readonly PackageType IbcAluminiumPressurizedAbove10kpa = new("ibc-aluminium-pressurized-above-10kpa","Intermediate bulk container, aluminium, pressurised > 10 kpa");
    public static readonly PackageType IbcBagFlexible = new("ibc-bag-flexible","Bag, flexible container");
    public static readonly PackageType IbcBagJumbo = new("ibc-bag-jumbo","Bag, jumbo");
    public static readonly PackageType IbcBagPalletSized = new("ibc-bag-pallet-sized","Large bag, pallet sized");
    public static readonly PackageType IbcComposite = new("ibc-composite","Intermediate bulk container, composite");
    public static readonly PackageType IbcCompositeFlexiblePlasticLiquids = new("ibc-composite-flexible-plastic-liquids","Intermediate bulk container, composite, flexible plastic, liquids ");
    public static readonly PackageType IbcCompositeFlexiblePlasticPressurised = new("ibc-composite-flexible-plastic-pressurised","Intermediate bulk container, composite, flexible plastic, pressurised");
    public static readonly PackageType IbcCompositeFlexiblePlasticSolids = new("ibc-composite-flexible-plastic-solids","Intermediate bulk container, composite, flexible plastic, solids");
    public static readonly PackageType IbcCompositeRigidPlasticLiquids = new("ibc-composite-rigid-plastic-liquids","Intermediate bulk container, composite, rigid plastic, liquids");
    public static readonly PackageType IbcCompositeRigidPlasticPressurised = new("ibc-composite-rigid-plastic-pressurised","Intermediate bulk container, composite, rigid plastic, pressurised ");
    public static readonly PackageType IbcCompositeRigidPlasticSolids = new("ibc-composite-rigid-plastic-solids","Intermediate bulk container, composite, rigid plastic, solids");
    public static readonly PackageType IbcFibreboard = new("ibc-fibreboard","Intermediate bulk container, fibreboard");
    public static readonly PackageType IbcFlexible = new("ibc-flexible","Intermediate bulk container, flexible");
    public static readonly PackageType IbcMetal = new("ibc-metal","Intermediate bulk container, metal ");
    public static readonly PackageType IbcMetalNoSteal = new("ibc-metal-no-steal","Intermediate bulk container, metal, other than steel");
    public static readonly PackageType IbcMetalLiquid = new("ibc-metal-liquid","Intermediate bulk container, metal, liquid ");
    public static readonly PackageType IbcMetalPressurized10kpa = new("ibc-metal-pressurized-10kpa","Intermediate bulk container, metal, pressure 10 kpa ");
    public static readonly PackageType IbcNaturalWood = new("ibc-natural-wood","Intermediate bulk container, natural wood");
    public static readonly PackageType IbcNaturalWoodInnerLiner = new("ibc-natural-wood-inner-liner","Intermediate bulk container, natural wood, with inner liner");
    public static readonly PackageType IbcPaperMultiWall = new("ibc-paper-multi-wall","Intermediate bulk container, paper, multi-wall ");
    public static readonly PackageType IbcPaperMultiWallWaterResistant = new("ibc-paper-multi-wall-water-resistant","Intermediate bulk container, paper, multi-wall, water resistant");
    public static readonly PackageType IbcPlasticFilm = new("ibc-plastic-film","Intermediate bulk container, plastic film");
    public static readonly PackageType IbcPlywood = new("ibc-plywood","Intermediate bulk container, plywood");
    public static readonly PackageType IbcPlywoodInnerLiner = new("ibc-plywood-inner-liner","Intermediate bulk container, plywood, with inner liner ");
    public static readonly PackageType IbcReconstitutedWood = new("ibc-reconstituted-wood","Intermediate bulk container, reconstituted wood");
    public static readonly PackageType IbcReconstitutedWoodInnerLiner = new("ibc-reconstituted-wood-inner-liner","Intermediate bulk container, reconstituted wood, with inner liner");
    public static readonly PackageType IbcRigidPlastic = new("ibc-rigid-plastic","Intermediate bulk container, rigid plastic");
    public static readonly PackageType IbcRigidPlasticFreestandingLiquids = new("ibc-rigid-plastic-freestanding-liquids","Intermediate bulk container, rigid plastic, freestanding, liquids");
    public static readonly PackageType IbcRigidPlasticFreestandingPressurised = new("ibc-rigid-plastic-freestanding-pressurised","Intermediate bulk container, rigid plastic, freestanding, pressurised");
    public static readonly PackageType IbcRigidPlasticFreestandingSolids = new("ibc-rigid-plastic-freestanding-solids","Intermediate bulk container, rigid plastic, freestanding, solids");
    public static readonly PackageType IbcRigidPlasticStructuralEquipmentLiquids = new("ibc-rigid-plastic-structural-equipment-liquids","Intermediate bulk container, rigid plastic, with structural equipment, liquids ");
    public static readonly PackageType IbcRigidPlasticStructuralEquipmentPressurised = new("ibc-rigid-plastic-structural-equipment-pressurised","Intermediate bulk container, rigid plastic, with structural equipment, pressurised");
    public static readonly PackageType IbcRigidPlasticStructuralEquipmentSolids = new("ibc-rigid-plastic-structural-equipment-solids","Intermediate bulk container, rigid plastic, with structural equipment, solids");
    public static readonly PackageType IbcSteel = new("ibc-steel","Intermediate bulk container, steel ");
    public static readonly PackageType IbcSteelLiquid = new("ibc-steel-liquid","Intermediate bulk container, steel, liquid ");
    public static readonly PackageType IbcSteelPressurizedAbove10kpa = new("ibc-steel-pressurized-above-10kpa","Intermediate bulk container, steel, pressurised > 10 kpa");
    public static readonly PackageType IbcTextileCoated = new("ibc-textile-coated","Intermediate bulk container, textile, coated ");
    public static readonly PackageType IbcTextileCoatedAndLiner = new("ibc-textile-coated-and-liner","Intermediate bulk container, textile, coated and liner ");
    public static readonly PackageType IbcTextileLiner = new("ibc-textile-liner","Intermediate bulk container, textile, with liner ");
    public static readonly PackageType IbcTextileOutCoatLiner = new("ibc-textile-out-coat-liner","Intermediate bulk container, textile with out coat/liner ");
    public static readonly PackageType IbcWovenPlasticCoated = new("ibc-woven-plastic-coated","Intermediate bulk container, woven plastic, coated ");
    public static readonly PackageType IbcWovenPlasticCoatedAndLiner = new("ibc-woven-plastic-coated-and-liner","Intermediate bulk container, woven plastic, coated and liner ");
    public static readonly PackageType IbcWovenPlasticWithLiner = new("ibc-woven-plastic-with-liner","Intermediate bulk container, woven plastic, with liner ");
    public static readonly PackageType IbcWovenPlasticWithoutCoatLiner = new("ibc-woven-plastic-without-coat-liner","Intermediate bulk container, woven plastic, without coat/liner ");
    public static readonly PackageType Jar = new("jar","Jar");
    public static readonly PackageType JerrycanCylindrical = new("jerrycan-cylindrical","Jerrycan, cylindrical");
    public static readonly PackageType JerrycanPlastic = new("jerrycan-plastic","Jerrycan, plastic");
    public static readonly PackageType JerrycanPlasticNonRemovableHead = new("jerrycan-plastic-non-removable-head","Jerrycan, plastic, non-removable head");
    public static readonly PackageType JerrycanPlasticRemovableHead = new("jerrycan-plastic-removable-head","Jerrycan, plastic, removable head");
    public static readonly PackageType JerrycanRectangular = new("jerrycan-rectangular","Jerrycan, rectangular");
    public static readonly PackageType JerrycanSteel = new("jerrycan-steel","Jerrycan, steel");
    public static readonly PackageType JerrycanSteelNonRemovableHead = new("jerrycan-steel-non-removable-head","Jerrycan, steel, non-removable head");
    public static readonly PackageType JerrycanSteelRemovableHead = new("jerrycan-steel-removable-head","Jerrycan, steel, removable head");
    public static readonly PackageType Jug = new("jug","Jug");
    public static readonly PackageType Keg = new("keg","Keg");
    public static readonly PackageType Liftvan = new("liftvan","Liftvan");
    public static readonly PackageType Net = new("net","Net");
    public static readonly PackageType NetRed = new("net-red","Rednet ");
    public static readonly PackageType NetTubePlastic = new("net-tube-plastic","Net, tube, plastic ");
    public static readonly PackageType NetTubeTextile = new("net-tube-textile","Net, tube, textile ");
    public static readonly PackageType PackageCardboardBottle = new("package-cardboard-bottle","Package, cardboard, with bottle grip-holes ");
    public static readonly PackageType PackPlasticExpandable = new("pack-plastic-expandable","Composite packaging, glass receptacle in expandable plastic pack");
    public static readonly PackageType PackPlasticSolid = new("pack-plastic-solid","Composite packaging, glass receptacle in solid plastic pack");
    public static readonly PackageType Pail = new("pail","Pail ");
    public static readonly PackageType Pallet = new("pallet","Pallet ");
    public static readonly PackageType PalletOneway = new("pallet-oneway","Oneway pallet");
    public static readonly PackageType Pallet100x120Chep = new("pallet-100x120-chep","Pallet, CHEP 100 cm x 120 cm");
    public static readonly PackageType Pallet110x110IsoT11 = new("pallet-110x110-iso-t11","Pallet, ISO T11");
    public static readonly PackageType Pallet1165x1165As = new("pallet-116.5x116.5-as","Pallet, AS 4068-1993");
    public static readonly PackageType Pallet40x60Chep = new("pallet-40x60-chep","Pallet, CHEP 40 cm x 60 cm");
    public static readonly PackageType Pallet60x100 = new("pallet-60x100","Pallet 60 X 100 cm");
    public static readonly PackageType Pallet60x80Chep = new("pallet-60x80-chep","CHEP pallet 60 cm x 80 cm ");
    public static readonly PackageType Pallet60x80Lpr = new("pallet-60x80-lpr","LPR pallet 60 cm x 80 cm");
    public static readonly PackageType Pallet80x100 = new("pallet-80x100","Pallet 80 X 100 cm");
    public static readonly PackageType Pallet80x120Chep = new("pallet-80x120-chep","Pallet, CHEP 80 cm x 120 cm");
    public static readonly PackageType Pallet80x120Lpr = new("pallet-80x120-lpr","LPR pallet 80 cm x 120 cm");
    public static readonly PackageType Pallet80x60 = new("pallet-80x60","Pallet, modular, collars 80cms * 60cms ");
    public static readonly PackageType PalletCase = new("pallet-case","Case, with pallet base ");
    public static readonly PackageType PalletCaseCardboard = new("pallet-case-cardboard","Case, with pallet base, cardboard");
    public static readonly PackageType PalletCaseMetal = new("pallet-case-metal","Case, with pallet base, metal");
    public static readonly PackageType PalletCasePlastic = new("pallet-case-plastic","Case, with pallet base, plastic");
    public static readonly PackageType PalletCaseWooden = new("pallet-case-wooden","Case, with pallet base, wooden ");
    public static readonly PackageType PalletExceptional = new("pallet-exceptional","Pallet with exceptional dimensions");
    public static readonly PackageType PalletModular80x100 = new("pallet-modular-80x100","Pallet, modular, collars 80cms * 100cms ");
    public static readonly PackageType PalletModular80x120 = new("pallet-modular-80x120","Pallet, modular, collars 80cms * 120cms ");
    public static readonly PackageType PalletOctabin = new("pallet-octabin","Octabin");
    public static readonly PackageType PalletPlastic60x80Srs = new("pallet-plastic-60x80-srs","Plastic pallet SRS 60 cm x 80 cm");
    public static readonly PackageType PalletPlastic80x120Srs = new("pallet-plastic-80x120-srs","Plastic pallet SRS 80 cm x 120 cm");
    public static readonly PackageType PalletPlatform = new("pallet-platform","Platform, unspecified weight or dimension");
    public static readonly PackageType PalletReturnable = new("pallet-returnable","Returnable pallet");
    public static readonly PackageType PalletSynthentic100x120 = new("pallet-synthentic-100x120","Synthetic pallet ISO 2");
    public static readonly PackageType PalletSynthentic80x120 = new("pallet-synthentic-80x120","Synthetic pallet ISO 1");
    public static readonly PackageType PalletTriwall = new("pallet-triwall","Pallet, triwall");
    public static readonly PackageType PalletWheeled81x60x16 = new("pallet-wheeled-81x60x16","Wheeled pallet with raised rim ( 81 x 60 x 16)");
    public static readonly PackageType PalletWheeled81x67x135 = new("pallet-wheeled-81x67x135","A wheeled pallet with raised rim (81 x 67 x 135)");
    public static readonly PackageType PalletWheeled81x72x135 = new("pallet-wheeled-81x72x135","A Wheeled pallet with raised rim (81 x 72 x 135)");
    public static readonly PackageType PalletWholesaler = new("pallet-wholesaler","Wholesaler pallet");
    public static readonly PackageType PalletWooden = new("pallet-wooden","Pallet, wooden");
    public static readonly PackageType PalletWooden40x80 = new("pallet-wooden-40x80","Wooden pallet  40 cm x 80 cm");
    public static readonly PackageType PaperWrapped = new("paper-wrapped","Package, paper wrapped");
    public static readonly PackageType Rack = new("rack","Rack ");
    public static readonly PackageType RackClothingHanger = new("rack-clothing-hanger","Rack, clothing hanger");
    public static readonly PackageType ReceptacleFibre = new("receptacle-fibre","Receptacle, fibre ");
    public static readonly PackageType ReceptacleGlass = new("receptacle-glass","Receptacle, glass ");
    public static readonly PackageType ReceptacleMetal = new("receptacle-metal","Receptacle, metal ");
    public static readonly PackageType ReceptaclePaper = new("receptacle-paper","Receptacle, paper ");
    public static readonly PackageType ReceptaclePlasticWrapped = new("receptacle-plastic-wrapped","Receptacle, plastic wrapped ");
    public static readonly PackageType ReceptaclePlastic = new("receptacle-plastic","Receptacle, plastic ");
    public static readonly PackageType ReceptacleWooden = new("receptacle-wooden","Receptacle, wooden ");
    public static readonly PackageType Reel = new("reel","Reel ");
    public static readonly PackageType Roll = new("roll","Roll ");
    public static readonly PackageType Sack = new("sack","Sack ");
    public static readonly PackageType Skid = new("skid","Skid ");
    public static readonly PackageType Spool = new("spool","Spool ");
    public static readonly PackageType Suitcase = new("suitcase","Suitcase ");
    public static readonly PackageType Tank = new("tank","Tank container, generic");
    public static readonly PackageType TankCylindrical = new("tank-cylindrical","Tank, cylindrical");
    public static readonly PackageType TankPlasticFlexi = new("tank-plastic-flexi","Flexitank");
    public static readonly PackageType TankRectangular = new("tank-rectangular","Tank, rectangular");
    public static readonly PackageType Tierce = new("tierce","Tierce");
    public static readonly PackageType Tray = new("tray","Tray ");
    public static readonly PackageType Trolly = new("trolly","Trolley");
    public static readonly PackageType Trunk = new("trunk","Trunk");
    public static readonly PackageType Tub = new("tub","Tub");
    public static readonly PackageType Tube = new("tube","Tube ");
    public static readonly PackageType TubeCollapsible = new("tube-collapsible","Tube, collapsible");
    public static readonly PackageType TubWithLid = new("tub-with-lid","Tub, with lid");
    public static readonly PackageType Vat = new("vat","Vat");
    
    // Additional for default. Note: Validation will FAIL if this is used
    public static readonly PackageType DEFAULT = new("DEFAULT", "DEFAULT");
    // ReSharper enable InconsistentNaming

    private PackageType(string name, string value) : base(name, value)
    {
    }

    public static implicit operator string(PackageType packageType) => packageType.Name;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
