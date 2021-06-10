import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { AudioContentModel } from 'src/app/models/audioContent/audio-content-model';


@Injectable({
    providedIn: 'root'
})
export class BonusesService {
    private uri = environment.baseURL + 'bonuses';
    constructor(private http: HttpClient) { }

    get(): Observable<any[]> {
        const headers = new HttpHeaders({
            'Content-Type': 'application/json',
            'Authorization': localStorage.getItem('token')
        });
        let options = { headers: headers }
        var httpRequest = this.http.get<[any]>(this.uri, options)
            .pipe(catchError(this.handleError));
        return httpRequest;
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

    private handleError(error: HttpErrorResponse) {
        return throwError(error.error);
    }
}