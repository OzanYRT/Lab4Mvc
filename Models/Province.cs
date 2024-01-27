using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4Cities.Models;

public class Province
{
    [Key]
    public string? ProvinceCode { get; set; }
    public string? ProvinceName { get; set; }
    public List<City>? Cities { get; set; }
}
