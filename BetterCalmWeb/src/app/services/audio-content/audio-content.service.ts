import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { AudioContentModel } from 'src/app/models/audioContent/audio-content-model';
import { BaseService } from '../base.service';


@Injectable({
    providedIn: 'root'
})
export class AudioContentService extends BaseService {
    private uri = environment.baseURL + 'audioContents';

    constructor(private http: HttpClient) {
        super();
    }

    add(body) {
        let options = { headers: this.headers };
        var httpRequest = this.http.post(this.uri, body, options)
            .pipe(catchError(this.handleError));
        return httpRequest;
    }

    getAudioContentById(id): Observable<AudioContentModel> {
        return this.http.get<AudioContentModel>(this.uri + '/' + id)
            .pipe(catchError(this.handleError));
    }

    get(): Observable<AudioContentModel[]> {
        return this.http.get<AudioContentModel[]>(this.uri)
            .pipe(catchError(this.handleError));
    }

    getAudioContentByCategory(categoryId: number): Observable<AudioContentModel[]> {
        return this.http.get<AudioContentModel[]>(this.uri + '/categories/' + categoryId)
            .pipe(catchError(this.handleError));
    }

    getAudioContentByPlaylist(playlistId: number): Observable<AudioContentModel[]> {
        return this.http.get<AudioContentModel[]>(this.uri + '/playlists/' + playlistId)
            .pipe(catchError(this.handleError));
    }

    update(body): Observable<any> {
        let options = { headers: this.headers };
        var httpRequest = this.http.put<any>(this.uri, body, options)
            .pipe(catchError(this.handleError));
        return httpRequest;
    }

    delete(id): Observable<any> {
        let options = { headers: this.headers };
        var httpRequest = this.http.delete<any>(this.uri + "/" + id, options)
            .pipe(catchError(this.handleError));
        return httpRequest;
    }
}