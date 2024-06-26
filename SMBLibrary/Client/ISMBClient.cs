/* Copyright (C) 2017-2021 Tal Aloni <tal.aloni.il@gmail.com>. All rights reserved.
 * 
 * You can redistribute this program and/or modify it under the terms of
 * the GNU Lesser Public License as published by the Free Software Foundation,
 * either version 3 of the License, or (at your option) any later version.
 */
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SMBLibrary.Client
{
    public interface ISMBClient
    {
        bool Connect(IPAddress serverAddress, SMBTransportType transport, string serverName = null);

        Task<bool> ConnectAsync(IPAddress serverAddress, SMBTransportType transport, string serverName = null);

        void Disconnect();

        NTStatus Login(string domainName, string userName, string password);

        NTStatus Login(string domainName, string userName, string password, AuthenticationMethod authenticationMethod);

        NTStatus Logoff();

        List<string> ListShares(out NTStatus status);

        ISMBFileStore TreeConnect(string shareName, out NTStatus status);

        uint MaxReadSize
        {
            get;
        }

        uint MaxWriteSize
        {
            get;
        }
    }
}
