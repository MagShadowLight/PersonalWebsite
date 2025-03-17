import { TestBed } from '@angular/core/testing';

import { ItemImageDataService } from './item-image-data.service';

describe('ItemImageDataService', () => {
  let service: ItemImageDataService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ItemImageDataService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
