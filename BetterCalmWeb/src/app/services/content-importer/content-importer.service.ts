import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from '../../../environments/environment';
import { BaseService } from '../base.service';

@Injectable({
    providedIn: 'root'
})
export class ContentImporterService extends BaseService {
    private uri = environment.baseURL + 'importers';
    constructor(private http: HttpClient) {
        super();
    }

    get(): Observable<[string]> {
        return this.http.get<[string]>(this.uri)
            .pipe(catchError(this.handleError));
    }

    add(body) {
        const headers = new HttpHeaders({
            'Content-Type': 'application/json',
        });
        let options = { headers: headers };
        var httpRequest = this.http.post(this.uri, body, options)
            .pipe(catchError(this.handleError));
        return httpRequest;
    }
}
