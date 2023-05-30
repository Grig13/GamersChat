import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { Product } from '../../models/product.model';
import { AuthorizeService } from '../../api-authorization/authorize.service';
import { ProductService } from '../../services/product.service';
import { ConfirmationService, MessageService, SelectItem } from 'primeng/api';

@Component({
  selector: 'app-store',
  templateUrl: './store.component.html',
  styleUrls: ['./store.component.css'],
  providers: [ConfirmationService, MessageService]
})
export class StoreComponent implements OnInit {
  products: Product[] = [];
  productList!: Observable<Product[]>;
  selectedProduct: Product | null = null;

  userId2: string | null = null;

  product: Product | undefined;

  displayAddModal: boolean = false;
  displayEditModal: boolean = false;
  displayAddCommentModal: boolean = false;
  displayConfirmationModal: boolean = false;
  isSubmitting: boolean = false;

  visible?: boolean;
  productId: any;
  productIdToDelete: any;
  commentToRemoveId: any;
  layout: string = 'list';

  addProductForm = new FormGroup({
    title: new FormControl('', Validators.required),
    description: new FormControl('', Validators.required),
    price: new FormControl('', Validators.required),
    imageUrl: new FormControl('', Validators.required),
    category: new FormControl('', Validators.required),
    isNew: new FormControl('New', Validators.required),
    canDeliver: new FormControl('Yes', Validators.required),
    city: new FormControl('', Validators.required),
    phoneNumber: new FormControl('', Validators.required),
    email: new FormControl('', Validators.required)
  });

  editProductForm = new FormGroup({
    title: new FormControl('', Validators.required),
    description: new FormControl('', Validators.required),
    price: new FormControl('', Validators.required),
    imageUrl: new FormControl('', Validators.required),
    category: new FormControl('', Validators.required),
    isNew: new FormControl('New', Validators.required),
    canDeliver: new FormControl('Yes', Validators.required),
    city: new FormControl('', Validators.required),
    phoneNumber: new FormControl('', Validators.required),
    email: new FormControl('', Validators.required)
  });

  constructor(
    private productService: ProductService,
    private authService: AuthorizeService,
    private messageService: MessageService, 
    private confirmationService: ConfirmationService
    ) { }

  ngOnInit(): void {
    this.refreshStorePage();
    this.authService.getUserId().subscribe((userId: string | null) => {
      this.userId2 = userId;
      console.log(this.userId2);
    })
  }

  showDialog() {
    this.visible = true;
  }
  

  httpGetProducts(): void{
    this.productService.getAllProducts().subscribe({
      next: (products: Product[]) => {
        this.products = products;
      },
      error: (response) => {
        console.log(response);
      }
    });
  }

  selectProduct(product: Product){
    this.selectedProduct = product;
  }


  showAddDialog(){
    this.displayAddModal = true;
  }

  hideAddDialog(){
    this.addProductForm.reset();
    this.displayAddModal = false;
  }

  showAddCommentDialog(){
    this.displayAddCommentModal = true;
  }

  hideAddCommentDialog(){
    this.displayAddCommentModal = false;
  }

  showEditDialog(product: Product){
    this.displayEditModal = true;
    if(product.id){
      this.productId = product.id;
    }
    this.editProductForm.controls.title.setValue(product.title);
    this.editProductForm.controls.description.setValue(product.description);
    this.editProductForm.controls.price.setValue(product.price.toString());
    this.editProductForm.controls.category.setValue(product.category);
    this.editProductForm.controls.imageUrl.setValue(product.imageUrl);
    this.editProductForm.controls.isNew.setValue(product.isNew);
    this.editProductForm.controls.canDeliver.setValue(product.canDeliver);
    this.editProductForm.controls.city.setValue(product.city);
    this.editProductForm.controls.phoneNumber.setValue(product.phoneNumber);
    this.editProductForm.controls.email.setValue(product.email);
  }

  hideEditDialog(){
    this.displayEditModal = false;
  }

  showDeleteDialog(product: Product){
    this.displayConfirmationModal = true;
    if(product.id){
      this.productIdToDelete = product.id;
    }
  }

  hideDeleteDialog(){
    this.displayConfirmationModal = false;
  }

  refreshStorePage(): void {
    this.productService.getAllProducts().subscribe({
      next: (products: Product[]) => {
        this.products = products;
      },
      error: (response) => {
        console.log(response);
      }
    });
  }
  

  httpAddProduct(): void {
    console.log("httpAddProduct method called.");
    if (this.addProductForm.valid && !this.isSubmitting) {
      this.authService.getUserId().subscribe((userId: string | null) => {
        if (userId) {
          const newProduct: Product = {
            title: this.addProductForm.controls.title.value!,
            price: +this.addProductForm.controls.price.value!,
            description: this.addProductForm.controls.description.value!,
            category: this.addProductForm.controls.category.value!,
            imageUrl: this.addProductForm.controls.imageUrl.value!,
            isNew: this.addProductForm.controls.isNew.value!,
            canDeliver: this.addProductForm.controls.canDeliver.value!,
            city: this.addProductForm.controls.city.value!,
            phoneNumber: this.addProductForm.controls.phoneNumber.value!,
            email: this.addProductForm.controls.email.value!,
            userId: userId
          };
  
          this.productService.addProduct(newProduct).subscribe(
            () => {
              console.log('Product added successfully');
              this.refreshStorePage();
            },
            (error: any) => {
              console.error('Failed to add product:', error);
              this.isSubmitting = false;
            }
          );
          this.hideAddDialog();
        }
      });
    }
  }
  
  
  


  editProduct(): void {
    if (this.editProductForm.valid) {
      const product = {
        title: this.editProductForm.controls.title.value!,
        description: this.editProductForm.controls.description.value!,
        price: +this.editProductForm.controls.price.value!,
        category: this.editProductForm.controls.category.value!,
        imageUrl: this.editProductForm.controls.imageUrl.value!,
        isNew: this.editProductForm.controls.isNew.value!,
        canDeliver: this.editProductForm.controls.canDeliver.value!,
        city: this.editProductForm.controls.city.value!,
        phoneNumber: this.editProductForm.controls.phoneNumber.value!,
        email: this.editProductForm.controls.email.value!
      };
      this.productService.editProduct(this.productId, product).subscribe(() => {
        this.refreshStorePage();
      });
      this.hideEditDialog();
    }
  }

  deleteProduct(productId: string): void {
    this.productService.deleteProduct(productId).subscribe(
      () => {
        console.log('Product deleted successfully');
        this.refreshStorePage();
        this.hideDeleteDialog();
      },
      (error: any) => {
        console.error('Failed to delete product:', error);
      }
    );
  }
  

}
