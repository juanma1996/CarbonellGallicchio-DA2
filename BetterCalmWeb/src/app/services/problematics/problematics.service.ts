import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from '../../../environments/environment';
import { ProblematicBasicInfo } from 'src/app/models/problematic/problematic-basic-info';

@Injectable({
    providedIn: 'root'
})
export class ProblematicsService {
    private uri = environment.baseURL + 'problematics';
    constructor(private http: HttpClient) { }

    get(): Observable<[ProblematicBasicInfo]> {
        return this.http.get<[ProblematicBasicInfo]>(this.uri)
            .pipe(catchError(this.handleError));
    }

    private handleError(error: HttpErrorResponse) {
        return throwError(error.error);
    }
}