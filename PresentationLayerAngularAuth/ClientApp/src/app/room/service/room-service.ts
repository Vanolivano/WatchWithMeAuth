import { HttpClient } from "@angular/common/http";
import { Inject } from "@angular/core";

export class RoomService {
    room: Room;

    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    }

    public createRoom(): Promise<Room> {
        let promise = new Promise<Room>((resolve, reject) => {
            this.http.get<Room>(this.baseUrl + 'room')
                .toPromise()
                .then(
                    res => { // Success
                        this.room = res;
                        resolve();
                    },
                    msg => { // Error
                        reject(msg);
                    }
                );
        });
        return promise;
    }

    public transformUrl(url: string): string {
        if (url == '' || url == null) { return; }
        let schema = "https://www.youtube.com/embed/";
        let idVideo = this.convertYoutube(url);
        if (idVideo != null)
            return schema + idVideo;
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