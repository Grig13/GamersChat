import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IUser } from 'src/api-authorization/authorize.service';
import { AuthorizeService } from 'src/api-authorization/authorize.service';
import { UserDTO } from 'src/models/UserDTO.model';
import { Product } from 'src/models/product.model';
import { ProductService } from 'src/services/product.service';
import { UserAttributesService } from 'src/services/user-attributes.service';
import { UserService } from 'src/services/user.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {

  productId: any;
  product!: Product;
  user?: IUser | null;
  userAttributes?: UserDTO;
  productUserId: any;

  showMessageTab: boolean = false;

  responsiveOptions: any[] = [
    {
        breakpoint: '1024px',
        numVisible: 5
    },
    {
        breakpoint: '768px',
        numVisible: 3
    },
    {
        breakpoint: '560px',
        numVisible: 1
    }
];

  constructor(private route: ActivatedRoute,
    private productService: ProductService,
    private authService: AuthorizeService,
    private userAttributesService: UserAttributesService) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.productId = params.get('id');
      console.log(this.productId);
    })
    this.getUser();
    this.httpGetProduct();
    
  }

  httpGetProduct(): void{
    this.productService.getProductById(this.productId).subscribe({
      next: (product: Product) => {
        this.product = product;
        this.productUserId = product.userId;
        console.log(this.productUserId);
        this.httpGetUserAttributes();
      },
      error: (response) => {
        console.log(response);
      }
    });
  }

  getUser(): void{
    this.authService.getUser().subscribe({
      next: (user: IUser | null) => {
        this.user = user;
      },
      error: (response) => {
        console.log(response);
      }
    })
  }

  httpGetUserAttributes(): void{
    this.userAttributesService.getAttributes(this.productUserId).subscribe({
      next: (attributes: UserDTO) => {
        this.userAttributes = attributes;
      },
      error: (response) => {
        console.log(response);
      }
    });
  }

  openMessageTab(): void {
    this.showMessageTab = !this.showMessageTab;
  }
}
