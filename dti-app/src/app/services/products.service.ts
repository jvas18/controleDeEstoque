import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class ProductService {

    private url: string = '';

    constructor(private http: HttpClient) {
        this.url = `${environment.urls.api}/products`;
    }

    getById(id: string): Observable<any> {
        return this.http.get<any>(`${this.url}/${id}`).pipe(map(response => response));
    }

    create(data: any): Observable<any> {
        return this.http.post<any>(`${this.url}`, data).pipe(map(response => response));
    }

    update(id: string, data: any): Observable<any> {
        return this.http.put<any>(`${this.url}/${id}`, data).pipe(map(response => response));
    }

    delete(id: string): Observable<any> {
        return this.http.delete<any>(`${this.url}/${id}`).pipe(map(response => response));
    }

    getAll() :  Observable<any>{
        return this.http.get<any>(`${this.url}`).pipe(map(response => response));
    }

    search(name:string) :  Observable<any>{
        return this.http.get<any>(`${this.url}/search/${name}`).pipe(map(response => response));
    }

}