import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from '../../../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class ContentImporterService {
    private uri = environment.baseURL + 'importers';
    constructor(private http: HttpClient) { }

    get(): Observable<[string]> {
        return this.http.get<[string]>(this.uri)
            .pipe(catchError(this.handleError));
    }

    add(body){
        const headers = new HttpHeaders({
            'Content-Type': 'application/json',
        });
        let options = { headers: headers };
        var httpRequest = this.http.post(this.uri, body, options)
        .pipe(catchError(this.handleError));
        return httpRequest;
    }

    private handleError(error: HttpErrorResponse) {
        return throwError(error.error);
    }
}
