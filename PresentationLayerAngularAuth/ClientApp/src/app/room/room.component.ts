import { Component, OnInit } from '@angular/core';
import { Pipe, PipeTransform } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { RoomService } from './service/room-service';

@Component({
  selector: 'app-room',
  templateUrl: './room.component.html',
  styleUrls: ['./room.component.css'],
})
export class RoomComponent implements OnInit {
  room: Room;
  public url: string;

  constructor(public roomService: RoomService) { }

  ngOnInit() {
    this.roomService.createRoom();
    this.url = this.roomService.transformUrl("https://www.youtube.com/embed/5CAPMA8f68U");
  }

  public transformUrl(url: string) {
    this.url = this.roomService.transformUrl(url);
  }
}

@Pipe({ name: 'safe' })
export class SafePipe implements PipeTransform {

  constructor(private sanitizer: DomSanitizer) { }

  public transform(url) {
    return this.sanitizer.bypassSecurityTrustResourceUrl(url);
  }
}
