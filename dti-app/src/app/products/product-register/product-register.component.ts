import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AppService } from 'src/app/services/app.service';
import { ProductService } from 'src/app/services/products.service';

@Component({
  selector: 'app-product-register',
  templateUrl: './product-register.component.html',
  styleUrls: ['./product-register.component.css'],
})
export class ProductRegisterComponent implements OnInit {
  constructor(
    private productService: ProductService,
    private appService: AppService,
    private router: Router,
    private actRoute: ActivatedRoute
  ) {}

  ngOnInit() {
    this.id = this.actRoute.snapshot.params.id;
    if (this.id) {
      this.titulo = 'Editar Produto';
      this.productService.getById(this.id).subscribe((resp) => {
        this.form.patchValue({
          name: resp.name,
          qtd: resp.qtd,
          price: resp.price,
        });
      });
    } else {
      this.titulo = 'Novo Produto';
    }
  }
  form = new FormGroup({
    name: new FormControl('', Validators.required),
    qtd: new FormControl('', Validators.required),
    price: new FormControl('', Validators.required),
  });
  titulo: any;
  id: any;

  save() {
    if (this.id) {
      this.productService.update(this.id, this.form.value).subscribe(() => {
        this.router.navigate(['/products']);
        this.appService.toastr.success('Produto editado');
      });
    } else {
      this.productService.create(this.form.value).subscribe(() => {
        this.router.navigate(['/products']);
        this.appService.toastr.success('Produto cadastrado');
      });
    }
  }
}
