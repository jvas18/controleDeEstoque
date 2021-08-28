import { Injectable, NgZone } from '@angular/core';
import { Router } from '@angular/router';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';

import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { AppService } from './services/app.service';

//import { LocaleService } from './locale';

declare var toastr: any;

@Injectable({
  providedIn: 'root',
})
export class AppHttpInterceptor implements HttpInterceptor {
  constructor(
    private zone: NgZone,
    private appService: AppService
  ) {}

  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    let newRequest = request.clone({});

    return next.handle(newRequest).pipe(
      tap(
        (event: HttpEvent<any>) => {},
        (error) => {
          this.zone.run(() => {
            this.resolveErrors(error);
          });
        }
      )
    );
  }

  private resolveErrors(response: any, refErrors: any[] = []) {
    let errors: any[] = response.error
      ? response.error.errors || []
      : response.errors || [];
    errors = errors.concat(refErrors);
    if (errors.length === 0) {
      errors.push('Ocorreu um erro ao processar sua requisição');
    }
    let msg = `${errors.map((e) => `${e}`).join('')}`;
    this.appService.toastr.error(msg);
  }
}
