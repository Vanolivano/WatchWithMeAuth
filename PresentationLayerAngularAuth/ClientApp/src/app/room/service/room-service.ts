import { HttpClient } from "@angular/common/http";
import { Inject } from "@angular/core";
import { Room } from "../model/Room";

export class RoomService {

    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    }

    public createRoom(): Promise<Room> {
        let promise = new Promise<Room>((resolve, reject) => {
            this.http.get<Room>(this.baseUrl + 'room')
                .toPromise()
                .then(
                    res => { // Success
                        resolve(res);
                    },
                    msg => { // Error
                        reject(msg);
                    }
                );
        });
        return promise;
    }

    public editRoom(room: Room) {
        console.log("Room " + room.name);
        this.http.post(this.baseUrl + 'room/edit', room).toPromise();
    }

    public transformUrl(url: string): string {
        if (url == '' || url == null) { return null; }
        let schema = "https://www.youtube.com/embed/";
        let idVideo = this.convertYoutube(url);
        if (idVideo != null)
            return schema + idVideo;
        else
            return null;
    }

    private convertYoutube(url: string) {
        let re = /^(https?:\/\/)?((www\.)?(youtube(-nocookie)?|youtube.googleapis)\.com.*(v\/|v=|vi=|vi\/|e\/|embed\/|user\/.*\/u\/\d+\/)|youtu\.be\/)([_0-9a-z-]+)/i;
        let result = url.match(re);
        if (result != null) {
            return url.match(re)[7];
        } else {
            return null;
        }
    }
}