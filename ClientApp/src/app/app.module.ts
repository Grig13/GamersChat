import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { DialogModule } from 'primeng/dialog';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { CommonModule } from '@angular/common';
import { MessageService, SharedModule } from 'primeng/api';
import { DataViewModule } from 'primeng/dataview';
import { RatingModule } from 'primeng/rating';
import { BrowserAnimationsModule, NoopAnimationsModule } from '@angular/platform-browser/animations';
import { NewsComponent } from './news/news.component';
import { StoreComponent } from './store/store.component';
import { ToastModule } from 'primeng/toast';
import { ToolbarModule } from 'primeng/toolbar';
import { TableModule } from 'primeng/table';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { TagModule } from 'primeng/tag';
import { DropdownModule } from 'primeng/dropdown';
import { DataViewLayoutOptions } from 'primeng/dataview';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { GalleriaModule } from 'primeng/galleria';
import { ImageModule } from 'primeng/image';
import { ChipModule } from 'primeng/chip';
import { ToastrModule } from 'ngx-toastr';
import { ChipsModule } from 'primeng/chips';
import { AvatarModule } from 'primeng/avatar';
import { UserProfileComponent } from './user-profile/user-profile/user-profile.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    NewsComponent,
    StoreComponent,
    ProductDetailsComponent,
    UserProfileComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    DialogModule,
    ReactiveFormsModule,
    ButtonModule,
    CardModule,
    CommonModule,
    SharedModule,
    DataViewModule,
    DropdownModule,
    FormsModule,
    ChipsModule,
    RatingModule,
    TagModule,
    ToastModule,
    GalleriaModule,
    ImageModule,
    AvatarModule,
    ConfirmDialogModule,
    TableModule,
    ChipModule,
    ToastModule,
    ToolbarModule,
    BrowserAnimationsModule,
    NoopAnimationsModule,
    ApiAuthorizationModule,
    ToastrModule.forRoot({
      enableHtml: true,
      timeOut: 10000,
      positionClass: 'toast-top-right',
      preventDuplicates: false,
    }),
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full'},
      { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthorizeGuard] },
      { path: 'news', component: NewsComponent, canActivate: [AuthorizeGuard] },
      { path: 'store', component: StoreComponent, canActivate: [AuthorizeGuard]},
      { path: 'store/details/:id', component: ProductDetailsComponent, canActivate: [AuthorizeGuard]},
      { path: 'profile/:id', component: UserProfileComponent, canActivate: [AuthorizeGuard] },
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }, DataViewLayoutOptions, MessageService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
