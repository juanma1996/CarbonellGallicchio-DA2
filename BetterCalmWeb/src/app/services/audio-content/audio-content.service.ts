import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { AudioContentModel } from 'src/app/models/audioContent/audio-content-model';


@Injectable({
    providedIn: 'root'
})
export class AudioContentService {
    private uri = environment.baseURL + 'audioContents';
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

    getAudioContentById(id): Observable<AudioContentModel> {
        return this.http.get<AudioContentModel>(this.uri + '/' + id)
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