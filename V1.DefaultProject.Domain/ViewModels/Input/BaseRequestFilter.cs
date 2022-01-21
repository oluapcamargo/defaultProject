using System;
using System.Collections.Generic;
using System.Text;

namespace V1.DefaultProject.Domain.ViewModels.Input
{
    public class BaseRequestFilter
    {
        public string TermoBusca { get; set; }
        public int Take { get; set; } = 100;
        public int Page { get; set; } = 1;
        public int Offset { get; set; } = 0;
        public string SortingProp { get; set; }
        public string Direction { get; set; }
        public bool Ascending { get; set; } = true;
        public bool Active { get; set; } = true;

        internal int Skip
        {
            get
            {
                if (Offset >= 0)
                    return (int)Offset;
                else
                {
                    if (Page >= 0)
                        return ((int)Page - 1) * Take;
                    else
                        return 0;
                }
            }
        }

        public bool DirectionAsc
        {
            get
            {
                return Direction == "asc";
            }
        }
    }
}
