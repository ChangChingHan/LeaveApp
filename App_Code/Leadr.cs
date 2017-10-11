using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data.Linq;
using System.Data.Linq.Mapping;


[Table (Name="leaders")]
public class Leaders
{
	public enum Authorize
	{
		Authorize_NON = 0,
		Authorize_APPR = 1,
		Authorize_REPORT = 2
	}
    [Column(Name = "leaderid", IsPrimaryKey = true, IsDbGenerated = true)]
    public int LeaderId { get; set; }

    [Column(Name = "bu_name")]
    public string BUName { get; set; }

	[Column(Name = "author")]
	byte author { get; set; }

	public Authorize Author
	{ get { return (Authorize)author; } set { } }

//     [Column(Name = "requestedon")]
//     public DateTime RequestedOn { get; set; }
// 
//     [Column(Name = "requireddate")]
//     public DateTime RequiredDate { get; set; }
// 
//     [Column(Name = "requiredtime")]
//     public string RequiredTime { get; set; }
// 
//     [Column(Name = "fromplace")]
//     public int FromPlace { get; set; }
// 
//     [Column(Name = "toplace")]
//     public int ToPlace { get; set; }
// 
//     [Column(Name = "remarks")]
//     public string Remarks { get; set; }
// 
//     [Column(Name = "status")]
//     public string Status { get; set; }
// 
//     private EntityRef<Place>  _fromplace;
//     private EntityRef<Place> _toplace;
// 
//     [Association(Name = "cabrequest_fromplace",
//            Storage = "_fromplace", ThisKey = "FromPlace", IsForeignKey = true, DeleteRule = "CASCADE")]
//     public Place FromPlaceEntity
//     {
//         get
//         {
//             return this._fromplace.Entity;
//         }
//         set
//         {
//             this._fromplace.Entity = value;
//         }
//     }
// 
// 
//     [Association(Name = "cabrequest_toplace",
//           Storage = "_toplace", ThisKey = "ToPlace", 
//           IsForeignKey = true, DeleteRule = "CASCADE")]
//     public Place ToPlaceEntity
//     {
//         get
//         {
//             return this._toplace.Entity;
//         }
//         set
//         {
//             this._toplace.Entity = value;
//         }
//     }
}
