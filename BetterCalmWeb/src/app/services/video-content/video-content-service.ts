import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { VideoContentBasicInfo } from 'src/app/models/videoContent/video-content-basic-info';


@Injectable({
    providedIn: 'root'
})
export class VideoContentService {
    private uri = environment.baseURL + 'videoContents';
    constructor(private http: HttpClient) { }


    add(body) {
        const headers = new HttpHeaders({
            'Content-Type': 'application/json',
            'Authorization': localStorage.getItem('token')
        });
        let options = { headers: headers };
        var httpRequest = this.http.post(this.uri, body, options)
            .pipe(catchError(this.handleError));
        return httpRequest;
    }

    getVideoContentById(id): Observable<VideoContentBasicInfo> {
        return this.http.get<VideoContentBasicInfo>(this.uri + '/' + id)
            .pipe(catchError(this.handleError));
    }

    get(): Observable<VideoContentBasicInfo[]> {
        return this.http.get<VideoContentBasicInfo[]>(this.uri)
            .pipe(catchError(this.handleError));
    }

    getVideoContentByCategory(categoryId: number): Observable<VideoContentBasicInfo[]> {
        return this.http.get<VideoContentBasicInfo[]>(this.uri + '/categories/' + categoryId)
            .pipe(catchError(this.handleError));
    }

    getVideoContentByPlaylist(playlistId: number): Observable<VideoContentBasicInfo[]> {
        return this.http.get<VideoContentBasicInfo[]>(this.uri + '/playlists/' + playlistId)
            .pipe(catchError(this.handleError));
    }

    update(body): Observable<any> {
        const headers = new HttpHeaders({
            'Content-Type': 'application/json',
            'Authorization': localStorage.getItem('token')
        });
        let options = { headers: headers };
        var httpRequest = this.http.put<any>(this.uri, body, options)
            .pipe(catchError(this.handleError));
        return httpRequest;
    }

    delete(id): Observable<any> {
        const headers = new HttpHeaders({
            'Content-Type': 'application/json',
            'Authorization': localStorage.getItem('token')
        });
        let options = { headers: headers };
        var httpRequest = this.http.delete<any>(this.uri + "/" + id, options)
            .pipe(catchError(this.handleError));
        return httpRequest;
    }

    private handleError(error: HttpErrorResponse) {
        return throwError(error.error);
    }
}