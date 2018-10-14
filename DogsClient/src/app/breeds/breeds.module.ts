import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { SharedModule } from './../shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';
import { BreedsListComponent } from './breeds-list/breeds-list.component';
import { BreedCreateComponent } from './breed-create/breed-create.component';
import { BreedUpdateComponent } from './breed-update/breed-update.component';
import { BreedDeleteComponent } from './breed-delete/breed-delete.component';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    RouterModule.forChild([
      { path: 'list/:id', component: BreedsListComponent },
      { path: 'list', component: BreedsListComponent },
      { path: 'create', component: BreedCreateComponent },
      { path: 'update/:id', component: BreedUpdateComponent},
      { path: 'delete/:id', component: BreedDeleteComponent }
    ])
  ],
  declarations: [
    BreedsListComponent,
    BreedCreateComponent,
    BreedUpdateComponent,
    BreedDeleteComponent,

  ]
})

export class BreedsModule { }
