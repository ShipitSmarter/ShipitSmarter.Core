using System.Text.Json.Serialization;
using Ardalis.SmartEnum;

namespace ShipitSmarter.Core.Enumerations.v1;

/// <summary>
/// Currency codes based on ISO 4217, see <a href="https://en.wikipedia.org/wiki/ISO_4217">wikipedia</a>
/// </summary>
[JsonConverter(typeof(SmartEnumNameConverter<CurrencyCode, string>))]
public class CurrencyCode : SmartEnum<CurrencyCode, string>
{
    // ReSharper disable InconsistentNaming
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static readonly CurrencyCode AED = new(nameof(AED) , "United Arab Emirates dirham", 2);
    public static readonly CurrencyCode AFN = new(nameof(AFN) , "Afghan afghani", 2);
    public static readonly CurrencyCode ALL = new(nameof(ALL) , "Albanian lek", 2);
    public static readonly CurrencyCode AMD = new(nameof(AMD) , "Armenian dram", 2);
    public static readonly CurrencyCode ANG = new(nameof(ANG) , "Netherlands Antillean guilder", 2);
    public static readonly CurrencyCode AOA = new(nameof(AOA) , "Angolan kwanza", 2);
    public static readonly CurrencyCode ARS = new(nameof(ARS) , "Argentine peso", 2);
    public static readonly CurrencyCode AUD = new(nameof(AUD) , "Australian dollar", 2);
    public static readonly CurrencyCode AWG = new(nameof(AWG) , "Aruban florin", 2);
    public static readonly CurrencyCode AZN = new(nameof(AZN) , "Azerbaijani manat", 2);
    public static readonly CurrencyCode BAM = new(nameof(BAM) , "Bosnia and Herzegovina convertible mark", 2);
    public static readonly CurrencyCode BBD = new(nameof(BBD) , "Barbados dollar", 2);
    public static readonly CurrencyCode BDT = new(nameof(BDT) , "Bangladeshi taka", 2);
    public static readonly CurrencyCode BGN = new(nameof(BGN) , "Bulgarian lev", 2);
    public static readonly CurrencyCode BHD = new(nameof(BHD) , "Bahraini dinar", 3);
    public static readonly CurrencyCode BIF = new(nameof(BIF) , "Burundian franc", 0);
    public static readonly CurrencyCode BMD = new(nameof(BMD) , "Bermudian dollar", 2);
    public static readonly CurrencyCode BND = new(nameof(BND) , "Brunei dollar", 2);
    public static readonly CurrencyCode BOB = new(nameof(BOB) , "Boliviano", 2);
    public static readonly CurrencyCode BOV = new(nameof(BOV) , "Bolivian Mvdol (funds code)", 2);
    public static readonly CurrencyCode BRL = new(nameof(BRL) , "Brazilian real", 2);
    public static readonly CurrencyCode BSD = new(nameof(BSD) , "Bahamian dollar", 2);
    public static readonly CurrencyCode BTN = new(nameof(BTN) , "Bhutanese ngultrum", 2);
    public static readonly CurrencyCode BWP = new(nameof(BWP) , "Botswana pula", 2);
    public static readonly CurrencyCode BYN = new(nameof(BYN) , "Belarusian ruble", 2);
    public static readonly CurrencyCode BZD = new(nameof(BZD) , "Belize dollar", 2);
    public static readonly CurrencyCode CAD = new(nameof(CAD) , "Canadian dollar", 2);
    public static readonly CurrencyCode CDF = new(nameof(CDF) , "Congolese franc", 2);
    public static readonly CurrencyCode CHE = new(nameof(CHE) , "WIR euro (complementary currency)", 2);
    public static readonly CurrencyCode CHF = new(nameof(CHF) , "Swiss franc", 2);
    public static readonly CurrencyCode CHW = new(nameof(CHW) , "WIR franc (complementary currency)", 2);
    public static readonly CurrencyCode CLF = new(nameof(CLF) , "Unidad de Fomento (funds code)", 4);
    public static readonly CurrencyCode CLP = new(nameof(CLP) , "Chilean peso", 0);
    public static readonly CurrencyCode COP = new(nameof(COP) , "Colombian peso", 2);
    public static readonly CurrencyCode COU = new(nameof(COU) , "Unidad de Valor Real (UVR) (funds code)", 2);
    public static readonly CurrencyCode CRC = new(nameof(CRC) , "Costa Rican colon", 2);
    public static readonly CurrencyCode CUC = new(nameof(CUC) , "Cuban convertible peso", 2);
    public static readonly CurrencyCode CUP = new(nameof(CUP) , "Cuban peso", 2);
    public static readonly CurrencyCode CVE = new(nameof(CVE) , "Cape Verdean escudo", 2);
    public static readonly CurrencyCode CZK = new(nameof(CZK) , "Czech koruna", 2);
    public static readonly CurrencyCode DJF = new(nameof(DJF) , "Djiboutian franc", 0);
    public static readonly CurrencyCode DKK = new(nameof(DKK) , "Danish krone", 2);
    public static readonly CurrencyCode DOP = new(nameof(DOP) , "Dominican peso", 2);
    public static readonly CurrencyCode DZD = new(nameof(DZD) , "Algerian dinar", 2);
    public static readonly CurrencyCode EGP = new(nameof(EGP) , "Egyptian pound", 2);
    public static readonly CurrencyCode ERN = new(nameof(ERN) , "Eritrean nakfa", 2);
    public static readonly CurrencyCode ETB = new(nameof(ETB) , "Ethiopian birr", 2);
    public static readonly CurrencyCode EUR = new(nameof(EUR) , "Euro", 2);
    public static readonly CurrencyCode FJD = new(nameof(FJD) , "Fiji dollar", 2);
    public static readonly CurrencyCode FKP = new(nameof(FKP) , "Falkland Islands pound", 2);
    public static readonly CurrencyCode GBP = new(nameof(GBP) , "Pound sterling", 2);
    public static readonly CurrencyCode GEL = new(nameof(GEL) , "Georgian lari", 2);
    public static readonly CurrencyCode GHS = new(nameof(GHS) , "Ghanaian cedi", 2);
    public static readonly CurrencyCode GIP = new(nameof(GIP) , "Gibraltar pound", 2);
    public static readonly CurrencyCode GMD = new(nameof(GMD) , "Gambian dalasi", 2);
    public static readonly CurrencyCode GNF = new(nameof(GNF) , "Guinean franc", 0);
    public static readonly CurrencyCode GTQ = new(nameof(GTQ) , "Guatemalan quetzal", 2);
    public static readonly CurrencyCode GYD = new(nameof(GYD) , "Guyanese dollar", 2);
    public static readonly CurrencyCode HKD = new(nameof(HKD) , "Hong Kong dollar", 2);
    public static readonly CurrencyCode HNL = new(nameof(HNL) , "Honduran lempira", 2);
    public static readonly CurrencyCode HTG = new(nameof(HTG) , "Haitian gourde", 2);
    public static readonly CurrencyCode HUF = new(nameof(HUF) , "Hungarian forint", 2);
    public static readonly CurrencyCode IDR = new(nameof(IDR) , "Indonesian rupiah", 2);
    public static readonly CurrencyCode ILS = new(nameof(ILS) , "Israeli new shekel", 2);
    public static readonly CurrencyCode INR = new(nameof(INR) , "Indian rupee", 2);
    public static readonly CurrencyCode IQD = new(nameof(IQD) , "Iraqi dinar", 3);
    public static readonly CurrencyCode IRR = new(nameof(IRR) , "Iranian rial", 2);
    public static readonly CurrencyCode ISK = new(nameof(ISK) , "Icelandic króna (plural: krónur)", 0);
    public static readonly CurrencyCode JMD = new(nameof(JMD) , "Jamaican dollar", 2);
    public static readonly CurrencyCode JOD = new(nameof(JOD) , "Jordanian dinar", 3);
    public static readonly CurrencyCode JPY = new(nameof(JPY) , "Japanese yen", 0);
    public static readonly CurrencyCode KES = new(nameof(KES) , "Kenyan shilling", 2);
    public static readonly CurrencyCode KGS = new(nameof(KGS) , "Kyrgyzstani som", 2);
    public static readonly CurrencyCode KHR = new(nameof(KHR) , "Cambodian riel", 2);
    public static readonly CurrencyCode KMF = new(nameof(KMF) , "Comoro franc", 0);
    public static readonly CurrencyCode KPW = new(nameof(KPW) , "North Korean won", 2);
    public static readonly CurrencyCode KRW = new(nameof(KRW) , "South Korean won", 0);
    public static readonly CurrencyCode KWD = new(nameof(KWD) , "Kuwaiti dinar", 3);
    public static readonly CurrencyCode KYD = new(nameof(KYD) , "Cayman Islands dollar", 2);
    public static readonly CurrencyCode KZT = new(nameof(KZT) , "Kazakhstani tenge", 2);
    public static readonly CurrencyCode LAK = new(nameof(LAK) , "Lao kip", 2);
    public static readonly CurrencyCode LBP = new(nameof(LBP) , "Lebanese pound", 2);
    public static readonly CurrencyCode LKR = new(nameof(LKR) , "Sri Lankan rupee", 2);
    public static readonly CurrencyCode LRD = new(nameof(LRD) , "Liberian dollar", 2);
    public static readonly CurrencyCode LSL = new(nameof(LSL) , "Lesotho loti", 2);
    public static readonly CurrencyCode LYD = new(nameof(LYD) , "Libyan dinar", 3);
    public static readonly CurrencyCode MAD = new(nameof(MAD) , "Moroccan dirham", 2);
    public static readonly CurrencyCode MDL = new(nameof(MDL) , "Moldovan leu", 2);
    public static readonly CurrencyCode MGA = new(nameof(MGA) , "Malagasy ariary", 2);
    public static readonly CurrencyCode MKD = new(nameof(MKD) , "Macedonian denar", 2);
    public static readonly CurrencyCode MMK = new(nameof(MMK) , "Myanmar kyat", 2);
    public static readonly CurrencyCode MNT = new(nameof(MNT) , "Mongolian tögrög", 2);
    public static readonly CurrencyCode MOP = new(nameof(MOP) , "Macanese pataca", 2);
    public static readonly CurrencyCode MRU = new(nameof(MRU) , "Mauritanian ouguiya", 2);
    public static readonly CurrencyCode MUR = new(nameof(MUR) , "Mauritian rupee", 2);
    public static readonly CurrencyCode MVR = new(nameof(MVR) , "Maldivian rufiyaa", 2);
    public static readonly CurrencyCode MWK = new(nameof(MWK) , "Malawian kwacha", 2);
    public static readonly CurrencyCode MXN = new(nameof(MXN) , "Mexican peso", 2);
    public static readonly CurrencyCode MXV = new(nameof(MXV) , "Mexican Unidad de Inversion (UDI) (funds code)", 2);
    public static readonly CurrencyCode MYR = new(nameof(MYR) , "Malaysian ringgit", 2);
    public static readonly CurrencyCode MZN = new(nameof(MZN) , "Mozambican metical", 2);
    public static readonly CurrencyCode NAD = new(nameof(NAD) , "Namibian dollar", 2);
    public static readonly CurrencyCode NGN = new(nameof(NGN) , "Nigerian naira", 2);
    public static readonly CurrencyCode NIO = new(nameof(NIO) , "Nicaraguan córdoba", 2);
    public static readonly CurrencyCode NOK = new(nameof(NOK) , "Norwegian krone", 2);
    public static readonly CurrencyCode NPR = new(nameof(NPR) , "Nepalese rupee", 2);
    public static readonly CurrencyCode NZD = new(nameof(NZD) , "New Zealand dollar", 2);
    public static readonly CurrencyCode OMR = new(nameof(OMR) , "Omani rial", 3);
    public static readonly CurrencyCode PAB = new(nameof(PAB) , "Panamanian balboa", 2);
    public static readonly CurrencyCode PEN = new(nameof(PEN) , "Peruvian sol", 2);
    public static readonly CurrencyCode PGK = new(nameof(PGK) , "Papua New Guinean kina", 2);
    public static readonly CurrencyCode PHP = new(nameof(PHP) , "Philippine peso", 2);
    public static readonly CurrencyCode PKR = new(nameof(PKR) , "Pakistani rupee", 2);
    public static readonly CurrencyCode PLN = new(nameof(PLN) , "Polish złoty", 2);
    public static readonly CurrencyCode PYG = new(nameof(PYG) , "Paraguayan guaraní", 0);
    public static readonly CurrencyCode QAR = new(nameof(QAR) , "Qatari riyal", 2);
    public static readonly CurrencyCode RON = new(nameof(RON) , "Romanian leu", 2);
    public static readonly CurrencyCode RSD = new(nameof(RSD) , "Serbian dinar", 2);
    public static readonly CurrencyCode CNY = new(nameof(CNY) , "Renminbi", 2);
    public static readonly CurrencyCode RUB = new(nameof(RUB) , "Russian ruble", 2);
    public static readonly CurrencyCode RWF = new(nameof(RWF) , "Rwandan franc", 0);
    public static readonly CurrencyCode SAR = new(nameof(SAR) , "Saudi riyal", 2);
    public static readonly CurrencyCode SBD = new(nameof(SBD) , "Solomon Islands dollar", 2);
    public static readonly CurrencyCode SCR = new(nameof(SCR) , "Seychelles rupee", 2);
    public static readonly CurrencyCode SDG = new(nameof(SDG) , "Sudanese pound", 2);
    public static readonly CurrencyCode SEK = new(nameof(SEK) , "Swedish krona (plural: kronor)", 2);
    public static readonly CurrencyCode SGD = new(nameof(SGD) , "Singapore dollar", 2);
    public static readonly CurrencyCode SHP = new(nameof(SHP) , "Saint Helena pound", 2);
    public static readonly CurrencyCode SLE = new(nameof(SLE) , "Sierra Leonean leone (new leone)", 2);
    public static readonly CurrencyCode SLL = new(nameof(SLL) , "Sierra Leonean leone (old leone)", 2);
    public static readonly CurrencyCode SOS = new(nameof(SOS) , "Somali shilling", 2);
    public static readonly CurrencyCode SRD = new(nameof(SRD) , "Surinamese dollar", 2);
    public static readonly CurrencyCode SSP = new(nameof(SSP) , "South Sudanese pound", 2);
    public static readonly CurrencyCode STN = new(nameof(STN) , "São Tomé and Príncipe dobra", 2);
    public static readonly CurrencyCode SVC = new(nameof(SVC) , "Salvadoran colón", 2);
    public static readonly CurrencyCode SYP = new(nameof(SYP) , "Syrian pound", 2);
    public static readonly CurrencyCode SZL = new(nameof(SZL) , "Swazi lilangeni", 2);
    public static readonly CurrencyCode THB = new(nameof(THB) , "Thai baht", 2);
    public static readonly CurrencyCode TJS = new(nameof(TJS) , "Tajikistani somoni", 2);
    public static readonly CurrencyCode TMT = new(nameof(TMT) , "Turkmenistan manat", 2);
    public static readonly CurrencyCode TND = new(nameof(TND) , "Tunisian dinar", 3);
    public static readonly CurrencyCode TOP = new(nameof(TOP) , "Tongan paʻanga", 2);
    public static readonly CurrencyCode TRY = new(nameof(TRY) , "Turkish lira", 2);
    public static readonly CurrencyCode TTD = new(nameof(TTD) , "Trinidad and Tobago dollar", 2);
    public static readonly CurrencyCode TWD = new(nameof(TWD) , "New Taiwan dollar", 2);
    public static readonly CurrencyCode TZS = new(nameof(TZS) , "Tanzanian shilling", 2);
    public static readonly CurrencyCode UAH = new(nameof(UAH) , "Ukrainian hryvnia", 2);
    public static readonly CurrencyCode UGX = new(nameof(UGX) , "Ugandan shilling", 0);
    public static readonly CurrencyCode USD = new(nameof(USD) , "United States dollar", 2);
    public static readonly CurrencyCode USN = new(nameof(USN) , "United States dollar (next day) (funds code)", 2);
    public static readonly CurrencyCode UYI = new(nameof(UYI) , "Uruguay Peso en Unidades Indexadas (URUIURUI) (funds code)", 0);
    public static readonly CurrencyCode UYU = new(nameof(UYU) , "Uruguayan peso", 2);
    public static readonly CurrencyCode UYW = new(nameof(UYW) , "Unidad previsional", 4);
    public static readonly CurrencyCode UZS = new(nameof(UZS) , "Uzbekistan sum", 2);
    public static readonly CurrencyCode VED = new(nameof(VED) , "Venezuelan digital bolívar", 2);
    public static readonly CurrencyCode VES = new(nameof(VES) , "Venezuelan sovereign bolívar", 2);
    public static readonly CurrencyCode VND = new(nameof(VND) , "Vietnamese đồng", 0);
    public static readonly CurrencyCode VUV = new(nameof(VUV) , "Vanuatu vatu", 0);
    public static readonly CurrencyCode WST = new(nameof(WST) , "Samoan tala", 2);
    public static readonly CurrencyCode XAF = new(nameof(XAF) , "CFA franc BEAC", 0);
    public static readonly CurrencyCode XAG = new(nameof(XAG) , "Silver (one troy ounce)", 0);
    public static readonly CurrencyCode XAU = new(nameof(XAU) , "Gold (one troy ounce)", 0);
    public static readonly CurrencyCode XBA = new(nameof(XBA) , "European Composite Unit (EURCO) (bond market unit)", 0);
    public static readonly CurrencyCode XBB = new(nameof(XBB) , "European Monetary Unit (E.M.U.-6) (bond market unit)", 0);
    public static readonly CurrencyCode XBC = new(nameof(XBC) , "European Unit of Account 9 (E.U.A.-9) (bond market unit)", 0);
    public static readonly CurrencyCode XBD = new(nameof(XBD) , "European Unit of Account 17 (E.U.A.-17) (bond market unit)", 0);
    public static readonly CurrencyCode XCD = new(nameof(XCD) , "East Caribbean dollar", 2);
    public static readonly CurrencyCode XDR = new(nameof(XDR) , "Special drawing rights", 0);
    public static readonly CurrencyCode XOF = new(nameof(XOF) , "CFA franc BCEAO", 0);
    public static readonly CurrencyCode XPD = new(nameof(XPD) , "Palladium (one troy ounce)", 0);
    public static readonly CurrencyCode XPF = new(nameof(XPF) , "CFP franc (franc Pacifique)", 0);
    public static readonly CurrencyCode XPT = new(nameof(XPT) , "Platinum (one troy ounce)", 0);
    public static readonly CurrencyCode XSU = new(nameof(XSU) , "SUCRE", 0);
    public static readonly CurrencyCode XTS = new(nameof(XTS) , "Code reserved for testing", 0);
    public static readonly CurrencyCode XUA = new(nameof(XUA) , "ADB Unit of Account", 0);
    public static readonly CurrencyCode XXX = new(nameof(XXX) , "No currency", 0);
    public static readonly CurrencyCode YER = new(nameof(YER) , "Yemeni rial", 2);
    public static readonly CurrencyCode ZAR = new(nameof(ZAR) , "South African rand", 2);
    public static readonly CurrencyCode ZMW = new(nameof(ZMW) , "Zambian kwacha", 2);
    public static readonly CurrencyCode ZWL = new(nameof(ZWL) , "Zimbabwean dollar (fifth)", 2);
    // Additional for default. Note: Validation will FAIL if this is used
    public static readonly CurrencyCode DEFAULT = new("DEFAULT", "DEFAULT", 0);
    // ReSharper enable InconsistentNaming

    public int NrOfDecimals { get; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

    private CurrencyCode(string name, string value, int nrOfDecimals) : base(name, value)
    {
        NrOfDecimals = nrOfDecimals;
    }
}
