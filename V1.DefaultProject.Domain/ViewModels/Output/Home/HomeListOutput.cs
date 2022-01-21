using System;
using System.Collections.Generic;
using System.Text;
using V1.DefaultProject.Domain.ViewModels.Output.Base;

namespace V1.DefaultProject.Domain.ViewModels.Output.Home
{
    public class HomeListOutput : BaseResponseOutput
    {
        public IEnumerable<HomeOutput> data { set; get; }
    }
}

