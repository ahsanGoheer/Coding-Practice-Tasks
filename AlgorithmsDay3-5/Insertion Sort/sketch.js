let values=[];
let w=5;
let states=[];
function setup()
{
  createCanvas(windowWidth,windowHeight);
  values = new Array(floor(width/w));
  
  for(var i=0;i<values.length;i++)
  {
      values[i]=random(height);
      states[i]=-1;
  }
  insertionSort(values);
}

async function insertionSort(values)
{
  
   
   for(var i=1;i<values.length;i++)
   {
     await sleep(100);
     let key=values[i];
     let j=i-1;
     states[i-1]=0;
     while(j>=0 && values[j]>key)
     {
       
       values[j+1]=values[j];
       j=j-1;
        
     }
     
     values[j+1]=key;
     
      
   }
  
}

function draw()
{
    background('pink');

    for(var i=0;i<values.length;i++)
    {
        stroke(0);
        if(states[i]==0)
        {
           
          fill('#DA22AA');
        }
        else
        {
            fill(255);
        }
        rect(i * w, height - values[i], w, values[i]);
    }
}

function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
  }