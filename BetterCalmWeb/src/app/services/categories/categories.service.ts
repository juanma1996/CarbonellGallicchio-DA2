import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from '../../../environments/environment';
import { CategoriesDashboardComponent } from '../../pages/categories/categories-dashboard/categories-dashboard.component';

export interface CategoryBasicInfo {
    id: number;
    name: string;
    audioContents: [];
  
}
@Injectable({
    providedIn: 'root'
})
export class CategoriesService {
    private uri = environment.baseURL + 'categories';
    constructor(private http: HttpClient) { }

    get(): Observable<[CategoryBasicInfo]> {
        return this.http.get<[CategoryBasicInfo]>(this.uri)
            .pipe(catchError(this.handleError));
    }

    private handleError(error: HttpErrorResponse) {
        return throwError(error.error);
    }
}