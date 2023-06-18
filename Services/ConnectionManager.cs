using System;
using System.Collections.Generic;

namespace GamersChat.Services
{
    public class ConnectionManager
    {
        private readonly Dictionary<string, string> _userConnections;

        public ConnectionManager()
        {
            _userConnections = new Dictionary<string, string>();
        }

        public string GenerateConnectionId()
        {
            string connectionId = Guid.NewGuid().ToString();
            return connectionId;
        }

        public void AddConnection(string userId, string connectionId)
        {
            _userConnections[userId] = connectionId;
        }

        public void RemoveConnection(string userId)
        {
            _userConnections.Remove(userId);
        }

        public string GetConnectionId(string userId)
        {
            _userConnections.TryGetValue(userId, out string connectionId);
            return connectionId;
        }
    }
}
