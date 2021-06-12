import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from '../../../environments/environment';
import { ProblematicBasicInfo } from 'src/app/models/problematic/problematic-basic-info';
import { BaseService } from '../base.service';

@Injectable({
    providedIn: 'root'
})
export class ProblematicsService extends BaseService {
    private uri = environment.baseURL + 'problematics';

    constructor(private http: HttpClient) {
        super();
    }

    get(): Observable<[ProblematicBasicInfo]> {
        return this.http.get<[ProblematicBasicInfo]>(this.uri)
            .pipe(catchError(this.handleError));
    }
}