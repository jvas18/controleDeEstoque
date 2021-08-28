import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { AppService } from 'src/app/services/app.service';
import { ProductService } from 'src/app/services/products.service';
import { ProductRemoveComponent } from '../product-remove/product-remove.component';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css'],
})
export class ProductListComponent implements OnInit {
  constructor(
    private productService: ProductService,
    private appService: AppService,
    private dialog: MatDialog
  ) {}

  products: any;
  ngOnInit() {
    this.productService.getAll().subscribe((resp) => {
      this.products = resp;
    });
  }
  name: any;
  search() {
    if (this.name == '' || !this.name) {
      this.productService.getAll().subscribe((resp) => {
        this.products = resp;
      });
    } else {
      this.productService.search(this.name).subscribe((resp) => {
        this.products = resp;
      });
    }
  }

  remove(id: any) {
    let dialogRef = this.dialog.open(ProductRemoveComponent);

    dialogRef.afterClosed().subscribe((result) => {
      if (result == 'true')
        this.productService.delete(id).subscribe(() => {
          this.appService.toastr.success('Produto excluído!');
          window.location.reload();
        });
    });
  }
}
