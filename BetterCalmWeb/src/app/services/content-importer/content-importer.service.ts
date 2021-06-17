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
        let options = { headers: this.headers };
        var httpRequest = this.http.get<[string]>(this.uri, options)
            .pipe(catchError(this.handleError));
        return httpRequest;
    }

    add(body) {
        let options = { headers: this.headers };
        var httpRequest = this.http.post(this.uri, body, options)
            .pipe(catchError(this.handleError));
        return httpRequest;
    }
}
