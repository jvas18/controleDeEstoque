import { Injectable, EventEmitter } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class AppService {

  constructor(
    private toastrService: ToastrService) {
    this.toastr = new CustomToastrService(this.toastrService);
  }

  public readonly ignoreStatusCodesHeaderKey = 'x-status-codes-to-ignore';


  toastr: CustomToastrService;

}
class CustomToastrService {

  constructor(private toastrService: ToastrService) {

  }

  private readonly defaultTitle: string = 'Atenção';

  success = (message: string, title?: string) => setTimeout(() => this.toastrService.success(message, title || this.defaultTitle));

  error = (message: string, title?: string) => setTimeout(() => this.toastrService.error(message, title || this.defaultTitle));

  info = (message: string, title?: string) => setTimeout(() => this.toastrService.info(message, title || this.defaultTitle));

  warning = (message: string, title?: string) => setTimeout(() => this.toastrService.warning(message, title || this.defaultTitle));

  clear = () => setTimeout(() => this.toastrService.clear());
}




