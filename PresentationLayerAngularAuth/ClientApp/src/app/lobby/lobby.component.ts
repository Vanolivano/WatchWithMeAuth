import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-lobby',
  templateUrl: './lobby.component.html',
  styleUrls: ['./lobby.component.css'],
})
export class LobbyComponent {
  // public room: Room;


  // constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  //   this.http.get<Room>(this.baseUrl + 'room').subscribe(result => {
  //     this.room = result;
  //   }, error => console.error(error));
  // }

  // public createRoom() {
  //   console.log("Start createRoom()");

  //   //console.log("After http.getRoom");
  //   console.log("Name room " + this.room.name);
  //   console.log("End createRoom()");
  // }
}
