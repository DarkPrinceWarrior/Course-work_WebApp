import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditAddToursComponent } from './edit-add-tours.component';

describe('EditAddToursComponent', () => {
  let component: EditAddToursComponent;
  let fixture: ComponentFixture<EditAddToursComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditAddToursComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditAddToursComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
