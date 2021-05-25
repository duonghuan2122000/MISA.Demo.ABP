import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BookDto, BookService, bookTypeOptions } from '@proxy/books';
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.scss'],
  providers: [
    ListService,
    {
      provide: NgbDateAdapter,
      useClass: NgbDateNativeAdapter,
    },
  ],
})
export class BookComponent implements OnInit {
  /**
   * Object chứa danh sách sách và tổng số trang
   * CreatedBy: dbhuan 25/05/2021
   */
  book = { items: [], totalCount: 0 } as PagedResultDto<BookDto>;

  /**
   * Sách đang được chọn (create hoặc update)
   * CreatedBy: dbhuan 25/05/2021
   */
  selectedBook = {} as BookDto;

  /**
   * FormControl angular
   * CreatedBy: dbhuan 25/05/2021
   */
  form: FormGroup;

  /**
   * Danh sách thể loại sách
   * CreatedBy: dbhuan 25/05/2021
   */
  bookTypes = bookTypeOptions;

  /**
   * trạng thái dialog thêm hoặc sửa sách
   * CreatedBy: dbhuan 25/05/2021
   */
  isModalOpen = false;

  /**
   * Hàm khởi tạo
   * @param list
   * @param bookService
   * @param fb
   * @param confirmation
   * CreatedBy: dbhuan 25/05/2021
   */
  constructor(
    public readonly list: ListService,
    private bookService: BookService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService
  ) {}

  /**
   * Lifecycle khởi tạo
   * CreatedBy: dbhuan 25/05/2021
   */
  ngOnInit(): void {
    // khởi tạo một stream chứa danh sách sách
    const bookStreamCreator = query => this.bookService.getList(query);

    // subscribe stream lấy giá trị khi có sự thay đổi.
    this.list.hookToQuery(bookStreamCreator).subscribe(response => {
      this.book = response;
    });
  }

  /**
   * Phương thức khởi tạo form thêm sách
   * CreatedBy: dbhuan 25/05/2021
   */
  createBook() {
    this.selectedBook = {} as BookDto;
    this.buildForm();
    this.isModalOpen = true;
  }

  /**
   * Phương thức khởi tạo form sửa sách
   * @param id id sách
   * CreatedBy: dbhuan 25/05/2021
   */
  editBook(id: string) {
    this.bookService.get(id).subscribe(book => {
      this.selectedBook = book;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  /**
   * Build form trong dialog thêm hoặc sửa sách
   * CreatedBy: dbhuan 25/05/2021
   */
  buildForm() {
    this.form = this.fb.group({
      name: [this.selectedBook.name || '', Validators.required],
      type: [this.selectedBook.type || null, Validators.required],
      publishDate: [
        this.selectedBook.publishDate ? new Date(this.selectedBook.publishDate) : null,
        Validators.required,
      ],
      price: [this.selectedBook.price || null, Validators.required],
    });
  }

  /**
   * Hàm lưu thông tin sách
   * CreatedBy: dbhuan 25/05/2021
   */
  save() {
    // Nếu valid thất bại
    if (this.form.invalid) {
      return;
    }

    // lưu thông tin sách
    const request = this.selectedBook.id
      ? this.bookService.update(this.selectedBook.id, this.form.value)
      : this.bookService.create(this.form.value);

    /**
     * đóng dialog và cập nhật sự thay đổi
     */
    request.subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.list.get();
    });
  }

  /**
   * phương thức xóa một quyển sách
   * @param id id sách
   * CreatedBy: dbhuan 25/05/2021
   */
  delete(id: string) {
    // Hiển thị dialog xác nhận
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe(status => {
      if (status === Confirmation.Status.confirm) {
        this.bookService.delete(id).subscribe(() => this.list.get());
      }
    });
  }
}
