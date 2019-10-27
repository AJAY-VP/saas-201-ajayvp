require 'sinatra'






def add_todo(todo)
  get_todos().push(todo)
end
def add_date(todo)
	get_dates().push(todo)
end
def get_dates
	@@dates ||=[]
end

get "/todos" do
  @todos = get_todos()
  @dates = get_dates()
  erb :todos
end

post "/todos" do
  add_todo(params[:title])
  add_date(params[:date])
  redirect "/todos"
end

put "/todos/:id" do
  @id = params[:id]
  update_todo(params[:title])
  redirect "/todos"
end

delete "/todos/:id" do
  @id = params[:id]
  delete_todo()
  delete_date()
  redirect "/todos"
end



get "/todos/:id" do
  @id = params[:id]
  @todo = get_todo()
  @date = get_date()
  erb :todo
end

def get_todo
  get_todos()[@id.to_i - 1]
end
def get_date
	get_dates()[@id.to_i-1]
end
def update_todo(title)
  get_todos()[@id.to_i - 1] = title
end
def get_todos
  @@todos ||= []
end
def delete_todo
  get_todos().slice!(@id.to_i - 1)
end
def delete_date
	get_dates().slice!(@id.to_i-1)
end
