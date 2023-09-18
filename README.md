# ConcurrencyParallelism

# What is Multitasking?
Is the concept of running multiple applications at a time.
# What is a thread?
a thread is a lightweight process, thread by default does not have name.
# Thread class 
Help us to perform tasks such as creating and setting the priority of a thread. We can use this class to control a thread and obtain status.
+ **Current thread**
Retrieve the name of the thread which is currently running.
+ **IsAlive**
Retrieve the thread status.
+ **Name**
Retrieve the thread name.
+ **Priority** 
Indicates the scheduling priority of a thread. By default, is normal. We can assign Highest, Above normal, normal, Below normal, or lowest value to the priority property.
+ **Interrupt** 
To interrupt the thread which is in the WaitSleepJoin status. 
+ **Join**
To block a thread until another thread has terminated. The main thread await until the child thread finish.
+ **Resume**
To resume a thread which has been suspended earlier.
+ **Sleep** 
To sleep a thread for a specific period of time.
+ **SpinWait**
To make a tread wait the number of times specified in the iteration parameter.
+ **Start**
To start a tread.
+ **Suspend** 
To suspend a tread.
Thread live cycle
 
+ **Protecting Shared resources**
By using
Interlocked.Increment(), lock Method, monitor Method
 

Monitor.Wait 
Wait for other threads to notify.
Monitor.Pulse
Notify to another thread.
Monitor.PulseAll
Notifies all others threads within a process

## ManualResetEvent
Wait until uno tread write o get something to read or get something. Is set order in treads.
 

## AutoResetEvent
Is used for sending signals between two threads. Both Thread share the same autoResetEventObject. Work in order inside the threads. When one thread is complete another thread is allowed.
Mutex is better than AutoResetEvent

 


## Mutex in multithreading
Is a Synchronization primitive that grants exclusive access to the shared resource to only on thread.
If a Thread acquires a Mutex, the second thread that wants to acquire that Mutex is suspended until the first thread release the Mutex.
 

## Semaphore
Is used to limit the number of threads that can have access to a share resource concurrently. Allows one or more threads to enter into the critical section and execute the task concurrently with thread safety.
 
## Dead Lock in Multithreads  
Is where two or more threads are unmoving or frozen in their execution because they are waiting for each other to finish.
We can resolve Deadlock in multithreading by many ways, using by acquiring locks in a specific order.
Using monitor.TryEnter() or Mutex

## Thread Pool 
Is the process of creating a collection of threads during the initialization of a multithread application, and then reusing those threads for new tasks as and when required, instead of creating new threads.
This is the best way to create Threads because use computer resource better 
 

# Asynchronous Programing
Asynchronous programing is a process that starts happening together at the same time. Call waits for the method to complete before continuing with the program flow. It leaves the users to bad experiences with blocked UI.

## Task based Asynchronous Pattern
Is base on Task<ItaskResult>, it is typically execute asynchronously on a thread pool.

## Thread vs Task
Both are use for parallel programing.
Thread is low-level and Task is higher-level.
Thread should be preferred for any long-running operations while a Task should be preferred for any other asynchronous programming 
Task can return result while there is not mechanism to return from thread.

## Task ways to start 
 
Wait 
The main thread is waiting until the child’s task is finished. Like joins in Threads.
 

## Continuation task
Is a task invoke by another task
 

## Async and Await 
Async turns a method into an asynchronous method, which allows you to use await keyword in its body. It does not freeze the UI.
Await suspends the calling method and yield control back to its caller until the await task is complete. It can be used only in async methods.
 

# Parallel Programing 
 
Running application y many computers’ cores.

## Parallel for loop
 
The main thread waits until the parallel for finish.
 

## ParallelOptions 
This class provide options to limit the number of concurrently executions loops method by MaxDegreeOfParallelism.

Termination a Parallel Loop 
 

