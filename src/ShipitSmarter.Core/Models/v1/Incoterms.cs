using System.ComponentModel.DataAnnotations;
using ShipitSmarter.Core.Enumerations.v1;

namespace ShipitSmarter.Core.Models.v1;

/// <summary>
/// Indicates the Responsibilities for Cost/Insurance/Risks for the shipment
/// </summary>
[Serializable]
public class Incoterms
{
    /// <summary>
    /// Describes the scope of the incoterm
    /// </summary>
    [Required]
    public IncotermScope Scope { get; set; }

    /// <summary>
    /// Any of the Incoterms as released in 2000,2010,2020
    /// </summary>
    [Required]
    public Incoterm Incoterm { get; set; }

    /// <summary>
    /// The Named Place that applies to the incoterm
    /// </summary>
    public string? Place { get; set; }

    /// <summary>
    /// The International Chamber of Commerce (ICC) releases updates periodically, indicate which version of the release is being applied
    /// </summary>
    [Required]
    [StringLength(4)]
    [RegularExpression("2000|2010|2020", ErrorMessage = "Version must be 2000, 2010 or 2020")]
    public string Version { get; set; } = string.Empty;
}
