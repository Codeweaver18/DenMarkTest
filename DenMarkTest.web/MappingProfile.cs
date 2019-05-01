using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DenMarkTest.web
{
    /// <summary>
    /// Automapper default DTOs=>Entities Mapping configuration
    /// </summary>
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            AllowNullDestinationValues = true;
        }
    }
}
