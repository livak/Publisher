using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Entities;

namespace WebService
{
    public class ServiceVariable
    {
        public VariableDto VariableDto { get; set; }

        public TerminalDto TerminalDto { get; set; }

        public TerminalDto TerminalDtoWhenTimeIsUp { get; set; }

        public System.Timers.Timer time = new System.Timers.Timer();

        public ServiceVariable(VariableDto variableDto)
        {
            VariableDto = variableDto;

        }
    }
}