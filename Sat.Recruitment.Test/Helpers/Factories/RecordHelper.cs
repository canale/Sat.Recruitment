using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Test.Helpers.Factories
{
    internal static class RecordHelper
    {
        public static readonly string Name =  "Agustina";
        public static readonly string Email =  "Agustina@gmail.com";
        public static readonly string Phone =  "+534645213542";
        public static readonly string Address =  "Garay y Otra Calle";
        public static readonly string UserType =  "SuperUser";
        public static readonly string Money =  "100";
        public static readonly char Separator =  ',';

        public static readonly string UserRecord =  $"{Name},{Email},{Phone},{Address},{UserType},{Money}";

    }
}

