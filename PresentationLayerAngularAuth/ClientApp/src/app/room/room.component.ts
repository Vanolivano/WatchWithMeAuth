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
    this.roomService.createRoom().then(res => this.room = res);
    this.url = this.roomService.transformUrl("https://youtu.be/eLAHSRmFFzE?list=RDMMeLAHSRmFFzE");
  }

  public transformUrl(url: string) {
    if (url != null && url != "") {
      let result = this.roomService.transformUrl(url);
      if (result != null)
        this.url = result;
    }
  }
}

@Pipe({ name: 'safe' })
export class SafePipe implements PipeTransform {

  constructor(private sanitizer: DomSanitizer) { }

  public transform(url) {
    return this.sanitizer.bypassSecurityTrustResourceUrl(url);
  }
}
