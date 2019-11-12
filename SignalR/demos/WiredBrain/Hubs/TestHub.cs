using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WiredBrain.Hubs
{
    public class TestHub : Hub
    {
        public TestHub()
        {

        }

        public async Task<bool> GetUpdateForOrder()
        {
            return await Task.FromResult(true);
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
    }
}
