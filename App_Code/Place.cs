using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data.Linq;
using System.Data.Linq.Mapping;


[Table(Name = "places")]
public class Place
{
    [Column(Name = "placeid", IsPrimaryKey = true, IsDbGenerated = true)]
    public int PlaceId { get; set; }

    [Column(Name = "placename")]
    public string PlaceName { get; set; }

}
