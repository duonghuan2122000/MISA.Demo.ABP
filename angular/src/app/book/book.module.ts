import { NgModule } from '@angular/core';

import { BookRoutingModule } from './book-routing.module';
import { BookComponent } from './book.component';
import { SharedModule } from '../shared/shared.module';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [BookComponent],
  imports: [SharedModule, BookRoutingModule, NgbDatepickerModule],
})
export class BookModule {}
