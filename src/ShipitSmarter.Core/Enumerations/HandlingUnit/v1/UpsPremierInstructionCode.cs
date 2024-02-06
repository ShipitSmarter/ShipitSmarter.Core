using System.Text.Json.Serialization;
using Ardalis.SmartEnum;

namespace ShipitSmarter.Core.Enumerations.HandlingUnit.v1;

/// <summary>
/// Instruction code for the Ups Premier service level associated with the handling unit
/// </summary>
[JsonConverter(typeof(SmartEnumNameConverter<UpsPremierInstructionCode, string>))]
public sealed class UpsPremierInstructionCode : SmartEnum<UpsPremierInstructionCode, string>
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    // ReSharper disable InconsistentNaming
    public static readonly UpsPremierInstructionCode U001 = new("001", "No Special Handling Required");
    public static readonly UpsPremierInstructionCode U002 = new("002", "Controlled Room Temperature (CRT) - Do Not Refrigerate, Maintain Temp Range = 15 - 25 C)");
    public static readonly UpsPremierInstructionCode U003 = new("003", "Refrigerate (Temp Range = 2-8 C");
    public static readonly UpsPremierInstructionCode U004 = new("004", "Frozen (Freezer) ( Temp Range <-20 C)");
    public static readonly UpsPremierInstructionCode U005 = new("005", "Dry Ice Replenish (Temp Range <-80 C)");
    public static readonly UpsPremierInstructionCode U006 = new("006", "Cryo - Liquid-Nitrogen dry-vapor (Temp Range < -150 C) - do not open liquid nitrogen tank");
    public static readonly UpsPremierInstructionCode U007 = new("007", "Return to Shipper");
    public static readonly UpsPremierInstructionCode U008 = new("008", "Expedite To Receiver - All Modes Up to and Including Extraction to Courier");
    public static readonly UpsPremierInstructionCode U009 = new("009", "Expedite To Receiver - UPS Air Network Only (Next Flight)");
    public static readonly UpsPremierInstructionCode U010 = new("010", "Expedite To Receiver - Ground Courier only (No Air)");
    public static readonly UpsPremierInstructionCode U011 = new("011", "Hold for Instruction");
    public static readonly UpsPremierInstructionCode U012 = new("012", "Hold for Will Call");
    public static readonly UpsPremierInstructionCode U014 = new("014", "Contact UPS Premier Control Tower");
    public static readonly UpsPremierInstructionCode U015 = new("015", "Upgrade to Weekend Delivery (if not delivered Friday)");
    // ReSharper enable InconsistentNaming

    private UpsPremierInstructionCode(string name, string value) : base(name, value)
    {
    }
    
    public static implicit operator string(UpsPremierInstructionCode upsPremierInstructionCode) => upsPremierInstructionCode.Name;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member    
}