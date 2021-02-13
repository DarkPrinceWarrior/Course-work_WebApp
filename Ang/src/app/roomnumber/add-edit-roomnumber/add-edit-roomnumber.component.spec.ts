import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditRoomnumberComponent } from './add-edit-roomnumber.component';

describe('AddEditRoomnumberComponent', () => {
  let component: AddEditRoomnumberComponent;
  let fixture: ComponentFixture<AddEditRoomnumberComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditRoomnumberComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditRoomnumberComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
