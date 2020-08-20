using FamilyTreeApi.DTOs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Helpers
{
    public class SignalService : Hub
    {
    }

}

//startConnection() : void {
//    this._hubConnection
//      .start()
//      .then(() => {
//        this.connectionIsEstablished = true;
//        console.log('Hub connection started');
//        this.connectionEstablished.emit(true);
//})
//      .catch(err => {
//        console.log('Error while establishing connection, retrying...');
//        setTimeout(function () { this.startConnection(); }, 5000);
//      });
//  }











