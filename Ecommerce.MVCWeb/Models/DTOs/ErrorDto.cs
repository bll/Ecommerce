using System;
using System.Collections.Generic;

namespace Ecommerce.MVCWeb.Models.DTOs
{
    public class ErrorDto
    {
        public ErrorDto() {
            Errors = new List<string>();
        }
        public List<String> Errors { get; set; }
    }
}
