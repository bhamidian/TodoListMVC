document.addEventListener('DOMContentLoaded', () => {

  
    const taskForm = document.getElementById('task-form');
    const taskFormSubmitButton = document.getElementById('submit-button');
    const taskIdInput = document.getElementById('task-id');
    const taskTitleInput = document.getElementById('task-title');
    const taskDescriptionInput = document.getElementById('task-description');
    const taskDueDateInput = document.getElementById('task-duedate');
    const taskCategorySelect = document.getElementById('task-category');
    const taskStatusSelect = document.getElementById('task-status');
    const taskList = document.getElementById('task-list');


    const categories = [
        { id: 1, name: 'کار' },
        { id: 2, name: 'شخصی' },
        { id: 3, name: 'خرید' },
        { id: 4, name: 'مطالعه' }
    ];


    const statuses = [
        { id: 0, name: 'انجام نشده', cssClass: 'status-pending' },
        { id: 1, name: 'در حال انجام', cssClass: 'status-inprogress' },
        { id: 2, name: 'انجام شده', cssClass: 'status-done' }
    ];


    let tasks = [];


    function getCategoryNameById(categoryId) {
        const category = categories.find(c => c.id === parseInt(categoryId));
        return category ? category.name : 'نامشخص';
    }


    function getStatusInfoById(statusId) {
        const status = statuses.find(s => s.id === parseInt(statusId));
        return status || statuses[0]; 
    }


    function populateSelects() {
       
        taskCategorySelect.innerHTML = ''; 
        categories.forEach(category => {
            const option = document.createElement('option');
            option.value = category.id;
            option.textContent = category.name;
            taskCategorySelect.appendChild(option);
        });

    
        taskStatusSelect.innerHTML = ''; 
        statuses.forEach(status => {
            const option = document.createElement('option');
            option.value = status.id;
            option.textContent = status.name;
            taskStatusSelect.appendChild(option);
        });
    }


    function resetForm() {
        taskForm.reset(); 
        taskIdInput.value = ''; 
        taskFormSubmitButton.textContent = 'افزودن تسک'; 
    }


    function renderTasks() {
        taskList.innerHTML = '';

        if (tasks.length === 0) {
            taskList.innerHTML = '<li class="empty-list-message">هیچ تسکی برای نمایش وجود ندارد.</li>';
            return;
        }

        tasks.forEach(task => {

            const categoryName = getCategoryNameById(task.categoryId);
            const statusInfo = getStatusInfoById(task.status);
            

            const displayDate = task.dueDate ? new Date(task.dueDate).toLocaleDateString('fa-IR') : 'بدون تاریخ';

            const taskItem = document.createElement('li');
            taskItem.className = `task-item ${statusInfo.cssClass}`; 
            taskItem.setAttribute('data-id', task.id); 

            taskItem.innerHTML = `
                <div class="task-info">
                    <strong>${task.title}</strong>
                    <small>دسته‌بندی: ${categoryName} / تاریخ: ${displayDate} / وضعیت: ${statusInfo.name}</small>
                    <p>${task.description || ''}</p>
                </div>
                <div class="task-actions">
                    <button class="edit-btn" data-id="${task.id}">✏️</button>
                    <button class="delete-btn" data-id="${task.id}">❌</button>
                </div>
            `;
            
            taskList.appendChild(taskItem);
        });
    }


    function handleFormSubmit(event) {
        event.preventDefault(); 

        const id = taskIdInput.value;
        const title = taskTitleInput.value;
        const description = taskDescriptionInput.value;
        const dueDate = taskDueDateInput.value;
        const categoryId = taskCategorySelect.value;
        const status = taskStatusSelect.value;

        if (!title) {
            alert('لطفاً عنوان تسک را وارد کنید.');
            return;
        }

        if (id) {

            const taskToUpdate = tasks.find(task => task.id === parseInt(id));
            if (taskToUpdate) {

                taskToUpdate.title = title;
                taskToUpdate.description = description;
                taskToUpdate.dueDate = dueDate;
                taskToUpdate.categoryId = categoryId;
                taskToUpdate.status = status;
                taskToUpdate.updatedAt = new Date().toISOString();
            }
        } else {

            const newTask = {
               
                id: Date.now(), 
                createdAt: new Date().toISOString(),
                updatedAt: null,

          
                title: title,
                description: description,
                dueDate: dueDate,
                dueDatePersian: null, 
                status: status,
                categoryId: categoryId,

            };

            tasks.unshift(newTask);
        }

        resetForm();
        
        renderTasks();
    }


    function handleListClick(event) {
        const target = event.target; 

        const taskItem = target.closest('.task-item');
        if (!taskItem) return; 

        const taskId = parseInt(taskItem.dataset.id);

        if (target.classList.contains('delete-btn')) {
            deleteTask(taskId);
        } else if (target.classList.contains('edit-btn')) {
            prepareEdit(taskId);
        }
    }


    function deleteTask(id) {
        if (confirm('آیا از حذف این تسک مطمئن هستید؟')) {
            tasks = tasks.filter(task => task.id !== id);
            
            renderTasks();
        }
    }


    function prepareEdit(id) {
        const taskToEdit = tasks.find(task => task.id === id);
        if (!taskToEdit) return;

        taskIdInput.value = taskToEdit.id;
        taskTitleInput.value = taskToEdit.title;
        taskDescriptionInput.value = taskToEdit.description;
        taskDueDateInput.value = taskToEdit.dueDate ? taskToEdit.dueDate.split('T')[0] : '';
        taskCategorySelect.value = taskToEdit.categoryId;
        taskStatusSelect.value = taskToEdit.status;

        taskFormSubmitButton.textContent = 'ذخیره تغییرات';

        window.scrollTo(0, 0);
        taskTitleInput.focus();
    }


    function init() {
        populateSelects();
        
        taskForm.addEventListener('submit', handleFormSubmit);
        taskList.addEventListener('click', handleListClick);


        renderTasks();
    }

  
    init();

});